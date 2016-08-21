using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    //si o si requiere un user autorizado
    [Authorize]
    [ExceptionControl]
    public class PersonBaseController<T> : Controller
        where T:class
    {   //creamos un controlado base , 
        //definimos un Ireposit, para utilizar las implementaciones de esa interface
        //tener un nombre de variable
        protected IRepository<T> _repository;

        public PersonBaseController()
        {
            _repository = new BaseRepository<T>();
        }
   
    }
}