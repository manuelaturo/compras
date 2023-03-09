﻿using compras.BD;
using compras.BD.Entities;
using compras.Models.Request;
using compras.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace compras.Service
{
    public class QuestionsService
    {
        public bool AddQuestions(QuesionsRQ quesions)
        {
            try
            {
                QuestionsDAO dao = new QuestionsDAO();

                return dao.AddQuestions(new QuetionsEntity (quesions.question,quesions.module,quesions.registerUser));
            }
            catch(Exception e)
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
                    quesions.registerUser,quesions.idQuestions));
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
               
                decimal costTotal = 0;

               

              
                response = getQuestions(dao.GetQuestions());


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    public List<QuetionsRS> getQuestions(List<QuetionsEntity> entities )
        {
            return entities.ConvertAll(x => new QuetionsRS(x.question, x.module, x.registerUser));
        }

        public void SendEmail (string module)
        {
            
            string table = "Visitas" + module;
            UsuariosDAO dao = new UsuariosDAO();
            string asunto = "Encuesta de servicio " + module;
            string body;
            List<UsuariosEntity> usuarios =  dao.GetUsuariosByquestions(table);
            usuarios.ForEach(
            x =>
            {
                body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Este Estimado " + x.nombre+ "</h1></br>" +
                                "<h2>Pedimos tu apoyo para ayudarnos a mejorar nuestro servicio," +
                    " dedicando 5 minutos de tu tiempo a contestar la siguiente encuesta:</h2>"+
                    " <h2>link</h2>";
                sendEmail(x.email,asunto, body);
            }
            );
        }
        public void sendEmail(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "manu.bambino@hotmail.com";
            string displayName = "Nombre Para Mostrar";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                client.Credentials = new NetworkCredential(from, "man120");
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