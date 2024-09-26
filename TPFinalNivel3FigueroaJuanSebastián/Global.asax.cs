using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TPFinalNivel3FigueroaJuanSebastián
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        //Agregamos el archivo sacado de la pagina de microsoft ASP .Net Error Handling
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Session.Add("Error", exc.ToString());
            Server.Transfer("Error.aspx", false);

            //la parte de abajo no nos interesa porque lo manejamos distinto
            //if (exc is HttpUnhandledException)
            //{
            //    // Pass the error on to the error page.
            //    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
            //}
        }
    }
}