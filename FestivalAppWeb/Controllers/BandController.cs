using FestivalApp.Model;
using FestivalAppWeb.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FestivalAppWeb.Controllers
{
    public class BandController : ApiController
    {
        // GET api/band
        public IEnumerable<Band> Get()
        {
            return BandRepository.GetBands();
        }
        // GET api/band/5
        public Band Get(int id)
        {
            return BandRepository.GetBand(id);
        }
    }
}
