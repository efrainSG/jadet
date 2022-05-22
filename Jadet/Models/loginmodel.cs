using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class loginmodel {
        public string usuario { get; set; }
        public Guid usrguid { get; set; }
        public string password { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }

        public HomeModel Home { get; set; } = new HomeModel();
    }

    public class HomeModel
    {
        public string Nombre { get; set; } 
        public string Slogan { get; set; }
        public string UrlLogo { get; set; }
        public string UrlImgIzq { get; set; }
        public string UrlImgDer { get; set; }
        public HomeModel()
        {
            Nombre = "Jadet";
            Slogan = "Bienvenidos a donde encontrarán todo el material para hacer sus sueños realidad.";
            UrlLogo = "https://scontent.fpbc2-2.fna.fbcdn.net/v/t1.18169-9/20108266_1237073399754940_1762086398717514755_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=09cbfe&_nc_eui2=AeH6gAI-WJATPCSi8qxLDSP04jlCDGlDTrbiOUIMaUNOtmE-485ObBhouwMZatCjwGs&_nc_ohc=jUw7LECdqgwAX-ElQr2&_nc_ht=scontent.fpbc2-2.fna&oh=00_AT-eQRP9WdoA3ySNjmwV7ziDVJBDslpkg0OglXRkLL__Mg&oe=62AE6DCD";
            UrlImgDer = "https://scontent.fpbc2-2.fna.fbcdn.net/v/t1.18169-9/10942667_346822018836111_1162743070653794593_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=e3f864&_nc_eui2=AeGHs6I9JLoeuzft1E0Gsytd7xao_8ehPlfvFqj_x6E-V9KD5w-g7xjpApIGukXbMRQ&_nc_ohc=uS-6xLkkIvYAX98mnNo&_nc_ht=scontent.fpbc2-2.fna&oh=00_AT_0FOnB0FSzSDHzm5tZhldO172oXgJeFe1N5WbqAYDo-A&oe=62ACA6DC";
        }
    }
}