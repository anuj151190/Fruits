using Azure;
using CommonInterfaceLibrary;
using CommonModelLibrary;
using CommonModelLibrary.Request;
using CommonModelLibrary.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProgramAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FruitController : Controller
    {
        private readonly IFruitAdd _fruitAdd;
        private readonly IFruitSearch _fruitSearch;
        public FruitController(IFruitAdd fruitAdd,IFruitSearch fruitSearch)
        {
            _fruitAdd = fruitAdd;
            _fruitSearch=fruitSearch;
        }

        [RequireHttps]
        [HttpPost]
        public async Task<ActionResult<string>> Add(FruitRequest fruit)
        {
            bool status = false;
            status = await _fruitAdd.validateFruitAsync(fruit, "validatefruit");
            if (status == true)
            {
                return await Task.FromResult(BadRequest(Constant._alreadyexisted));
            }
            else
            {
                status = await _fruitAdd.AddAsync(fruit, "insert");
                if (status == true)
                {
                    return await Task.FromResult(Ok(Constant._successfully));
                }
            }
            return await Task.FromResult(BadRequest(Constant._internalserver));
        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<FruitsResponse>>> All()
        {
            try
            {
                List<FruitsResponse> list = new List<FruitsResponse>();
                list = await _fruitSearch.allAsync();
                if (list.Count == 0)
                {
                    return await Task.FromResult(NotFound(Constant._notfound));
                }
                else
                {
                    return await Task.FromResult(list);
                }
            }
            catch(Exception)
            {
                return await Task.FromResult(BadRequest(Constant._internalserver));
            }
        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<FruitsResponse>>> nutritions(float Min, float Max)
        {
            try
            {
                SearchFilter sf = new SearchFilter();
                sf.Min = Min;
                sf.Max = Max;
                List<FruitsResponse> list = new List<FruitsResponse>();
                list = await _fruitSearch.getAsync(sf, "getnutritions");
                if (list.Count == 0)
                {
                    return await Task.FromResult(NotFound(Constant._notfound));
                }
                else
                {
                    return await Task.FromResult(list.ToList());
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest(Constant._internalserver));
            }

        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<FruitsResponse>>> family(string family)
        {
            try
            {
                SearchFilter sf = new SearchFilter();
                sf.NutritionFilter = family;
                List<FruitsResponse> list = new List<FruitsResponse>();
                list = await _fruitSearch.getAsync(sf, "getfamily");
                if (list.Count == 0)
                {
                    return await Task.FromResult(NotFound(Constant._notfound));
                }
                else
                {
                    return await Task.FromResult(list);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest(Constant._internalserver));
            }
        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<FruitsResponse>>> genus(string genus)
        {
            try
            {
                SearchFilter sf = new SearchFilter();
                sf.NutritionFilter = genus;
                List<FruitsResponse> list = new List<FruitsResponse>();
                list = await _fruitSearch.getAsync(sf, "getgenus");
                if (list.Count == 0)
                {
                    return await Task.FromResult(NotFound(Constant._notfound));
                }
                else
                {
                    return await Task.FromResult(list);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest(Constant._internalserver));
            }
        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<FruitsResponse>>> order(string order)
        {
            try
            {
                SearchFilter sf = new SearchFilter();
                sf.NutritionFilter = order;
                List<FruitsResponse> list = new List<FruitsResponse>();
                list = await _fruitSearch.getAsync(sf, "getorder");
                if (list.Count == 0)
                {
                    return await Task.FromResult(NotFound(Constant._notfound));
                }
                else
                {
                    return await Task.FromResult(list);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(BadRequest(Constant._internalserver));
            }
        }
    }
}
