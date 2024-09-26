using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace Voolt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class adServiceController : ControllerBase
    {
        private readonly ILogger<adServiceController> _logger;
        private List<adObject> _adObjectList;

        public adServiceController(ILogger<adServiceController> logger)
        {
            _logger = logger;
            _adObjectList = LoadInitialadObjectList();
        }

    
        [HttpGet]
        public List<adObject> GetAlladObjects()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            List<adObject> adObjectList = new();
            adObjectList = GetAdObjects();
            
            return adObjectList;
        }
        private List<adObject> LoadInitialadObjectList()
        {
            
            //In the real world, it shoudl be a database query / request.
            List<adObject> adObjectList = new();

            adObject adObjectItem = new();
            adObjectItem.adId = 1;
            adObjectItem.adDescription = "ad Object Test 01";
            adObjectItem.adCreationDate = DateTime.Now;
            adObjectItem.adStatus = adStatus.Active;
            adObjectItem.adBalance = 100;
            adObjectItem.adExternalId = "Ext001";
            adObjectItem.adTotalLeads = 50;
            adObjectList.Add(adObjectItem);

            adObjectItem = new();
            adObjectItem.adId = 2;
            adObjectItem.adDescription = "ad Object Test 02";
            adObjectItem.adCreationDate = DateTime.Now;
            adObjectItem.adStatus = adStatus.Active;
            adObjectItem.adBalance = 200;
            adObjectItem.adExternalId = "Ext002";
            adObjectItem.adTotalLeads = 80;
            adObjectList.Add(adObjectItem);

            adObjectItem = new();
            adObjectItem.adId = 3;
            adObjectItem.adDescription = "ad Object Test 03";
            adObjectItem.adCreationDate = DateTime.Now;
            adObjectItem.adStatus = adStatus.Paused;
            adObjectItem.adBalance = 200;
            adObjectItem.adExternalId = "Ext003";
            adObjectItem.adTotalLeads = 80;
            adObjectList.Add(adObjectItem);

            return adObjectList;
            
        }

        private List<adObject> GetAdObjects()
        {
            //In the real world, it shoudl be a database query / request.
            return _adObjectList;
        }


        [HttpPost]
        public void UpdateadObject([FromBody] adObject newadObject)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            List<adObject> adObjectList = new();
            adObjectList = GetAdObjects();

            //Check if the adObject already exists
            if (adObjectList.Count > 0 && adObjectList.Where(x => x.adId == newadObject.adId).Count() > 0)
            {
                int currentItemIndex = adObjectList.FindIndex(x => x.adId == newadObject.adId);
                adObjectList.RemoveAt(currentItemIndex);
                adObjectList.Insert(currentItemIndex, newadObject);
            }
            else
            {
                adObjectList.Add(newadObject);
            }

            UpdatedObjectList(adObjectList);


        }

        private void UpdatedObjectList(List<adObject> adObjectList)
        {
            //In the real world, it shoudl be a database query / request.
           _adObjectList = adObjectList;
        }
    }
}
