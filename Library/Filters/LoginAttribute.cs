using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace BancoDePalavras.Library.Filters {
    public class LoginAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext context) {

            //verfica se h� uma sess�o iniciada
            if (context.HttpContext.Session.GetString("Login") == null) {

                //esse c�digo possibilita o uso de TempData com uma classe que n�o � do tipo Controller
                if (context.Controller != null) {
                    var controlador = context.Controller as Controller;
                    controlador.TempData["MensagemErro"] = "Fa�a Login para acessar o conte�do!";
                }
                //se n�o h� sess�o redireciona para login novamente
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}