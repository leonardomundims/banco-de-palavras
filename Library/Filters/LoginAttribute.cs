using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace BancoDePalavras.Library.Filters {
    public class LoginAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext context) {

            //verfica se há uma sessão iniciada
            if (context.HttpContext.Session.GetString("Login") == null) {

                //esse código possibilita o uso de TempData com uma classe que não é do tipo Controller
                if (context.Controller != null) {
                    var controlador = context.Controller as Controller;
                    controlador.TempData["MensagemErro"] = "Faça Login para acessar o conteúdo!";
                }
                //se não há sessão redireciona para login novamente
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}