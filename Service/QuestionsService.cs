using compras.BD;
using compras.BD.Entities;
using compras.Models.Request;
using compras.Models.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace compras.Service
{
    public class QuestionsService
    {
              private readonly string link = ConfigurationManager.ConnectionStrings["Survey"].ConnectionString;
        Dictionary<int, string> modules = new Dictionary<int, string>() {{1, "Comedor"},{2, "Salas"},{3, "Eventos"},{4, "Guias"},};
        public bool AddQuestions(QuesionsRQ quesions)
        {
            try
            {
                QuestionsDAO dao = new QuestionsDAO();

                return dao.AddQuestions(new QuetionsEntity (quesions.question,quesions.module,quesions.registerUser,null));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool deleteQuestions(int idQUestions)
        {
            try
            {
                QuestionsDAO dao = new QuestionsDAO();

                return dao.deleteQuestions(idQUestions);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool UpdateQuestions(QuesionsRQ quesions)
        {
            try
            {
                QuestionsDAO dao = new QuestionsDAO();

                return dao.UpdateQuestions(new QuetionsEntity(quesions.question, quesions.module, 
                    quesions.registerUser,quesions.idQuestions,null));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<QuetionsRS> getQuestions(string initDate, string endDate)
        {
            try
            {
                var dateInit = DateTime.ParseExact(initDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                var dateEnd = DateTime.ParseExact(endDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                List<QuetionsRS> response = new List<QuetionsRS>();
                QuestionsDAO dao = new QuestionsDAO();
                response = getQuestions(dao.GetQuestions(dateInit, dateEnd));


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<QuetionsRS> getQuestions()
        {
            try
            {
                List<QuetionsRS> response = new List<QuetionsRS>();
                QuestionsDAO dao = new QuestionsDAO();
                response = getQuestions(dao.GetQuestions());


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<QuetionsRS> getQuestions(int module)
        {
            try
            {
                List<QuetionsRS> response = new List<QuetionsRS>();
                QuestionsDAO dao = new QuestionsDAO();

                response = getQuestions(dao.GetQuestions(module));


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
            public List<QuetionsRS> getQuestions(List<QuetionsEntity> entities)
            {
                return entities.ConvertAll(x => new QuetionsRS(x.question, x.module, x.registerUser,x.nameModule));
            }

            public void SendEmail(string module,string email)
            {
            int idmodule=0;
              
                UsuariosDAO dao = new UsuariosDAO();
                string asunto = "Encuesta de servicio " + module;
                string body;
                List<UsuariosEntity> usuarios = dao.GetUsuariosByquestions(email);
            //mejorar este codigo
            if (module.Contains("Comedor"))
            {
                idmodule = 1;
            }else if (module.Contains("Salas"))
            {
                idmodule = 2;
            }
            else if (module.Contains("Eventos"))
            {
                idmodule = 3;
            }
            else if (module.Contains("Guias"))
            {
                idmodule = 4;
            }
            usuarios.ForEach(
                x =>
                {
                    var l = link + "module="+ idmodule.ToString() + "&user="+ x.Id_Usuario;
                    body = @"<h1>Este Estimado " + x.nombre + "</h1></br>" +
                                    "<h2>Pedimos tu apoyo para ayudarnos a mejorar nuestro servicio," +
                        " dedicando 5 minutos de tu tiempo a contestar la siguiente encuesta:</h2>" +
                        " <h2>" + l +"</h2>";
                    sendEmail(x.email, asunto, body);
                }
                );
            }
        private string getRandomModule()
        {
           
            Random r = new Random();
            
            modules.TryGetValue(r.Next(1, 4), out string moduleRandom);
            return moduleRandom.ToString();
        } 
        public void SendEmailRandom()
        {

         
            UsuariosDAO dao = new UsuariosDAO();
           
            string body;
            for (int i = 1; i <= 10; i++) {
                Random r = new Random();
                string module = getRandomModule();
                string asunto = "Encuesta de servicio " + module;
                int idmodule = 0;
                if (module.Contains("Comedor"))
                {
                    idmodule = 1;
                }
                else if (module.Contains("Salas"))
                {
                    idmodule = 2;
                }
                else if (module.Contains("Eventos"))
                {
                    idmodule = 3;
                }
                else if (module.Contains("Guias"))
                {
                    idmodule = 4;
                }
                UsuariosEntity usuarios = dao.GetUsuariosByquestions(r.Next(1, 100));

                var l = link + "module=" + idmodule.ToString() + "&user=" + usuarios.Id_Usuario;
                body = @"<h1>Este Estimado " + usuarios.nombre + "</h1></br>" +
                                    "<h2>Pedimos tu apoyo para ayudarnos a mejorar nuestro servicio," +
                        " dedicando 5 minutos de tu tiempo a contestar la siguiente encuesta:</h2>" +
                        " <h2>" + l + "</h2>";
                    sendEmail(usuarios.email, asunto, body);
                
            }
        }
        public void sendEmail(string to, string asunto, string body)
            {
                string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
                string from = "eventosycomedor@sapv.com.mx";
                string displayName = asunto;
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(to);

                    mail.Subject = asunto;
                    mail.Body = body;
                    mail.IsBodyHtml = true;


                    SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                    client.Credentials = new NetworkCredential(from, "4Dministracion.23");
                    client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                    client.Send(mail);
                    msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

                }
                catch (Exception ex)
                {
                    msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
                }


            }
        }

    }
