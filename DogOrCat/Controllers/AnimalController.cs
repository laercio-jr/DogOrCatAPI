using DogOrCat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DogOrCat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;

        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string urlApiDog = "https://dog.ceo/api/breeds/image/random";
            string urlApiCat = "https://api.thecatapi.com/v1/images/search";

            try
            {
                using (var img = new HttpClient())
                {

                    //var res = rndBool ? img.GetStringAsync(urlApiDog) : img.GetStringAsync(urlApiCat); TERNÁRIO NÃO FUNCIONA NESSE CASO;

                    if (Convert.ToBoolean(new Random().Next(2)))
                    {
                        var res = img.GetStringAsync(urlApiDog);
                        res.Wait();
                        var ret = JsonConvert.DeserializeObject<Dog>(res.Result);
                        return ret.message.ToString();
                    }
                    else
                    {
                        var res = img.GetStringAsync(urlApiCat);
                        res.Wait();
                        var ret = JsonConvert.DeserializeObject<List<Cat>>(res.Result);
                        return ret[0].url.ToString();
                    }

                }

            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
