﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCPlantilla.Utilerias;

namespace MvcPlantilla.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(int idvideo, string titulo, int reproducciones, string link)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@link", link));
            BaseHelper.ejecutarSentencia("Sp_Agregar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Modificar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(int idvideo, string titulo, int reproducciones, string link)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@link", link));
            BaseHelper.ejecutarSentencia("Sp_Modificar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(int idvideo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idvideo", idvideo));
            BaseHelper.ejecutarSentencia("Sp_Eliminar", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Home");
        }
    }
}
