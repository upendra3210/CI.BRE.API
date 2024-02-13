using CI.BRE.REPOSITERY.Entities;
using CI.BRE.SERVICE.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CI.BRE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CUDController : ControllerBase
    {
        private readonly IService<SpsBrArgumentValue> _service;
       

        public CUDController(IService<SpsBrArgumentValue> service)
        {
            _service = service;
           
        }

        [HttpGet]
        public async Task<ActionResult<SpsBrArgumentValue>> Get()
        {
            
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("id")]
        public async Task<ActionResult> getbyid(int br_key)
        {
            var data = await _service.GetByIdAsync(br_key);
            return Ok(data);
        }
        [HttpPut]
        public async Task<ActionResult> put(int id, insertdata temparyTable1)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            data.ProvinceState = temparyTable1.ProvinceState;
            data.ArgumentType = temparyTable1.ArgumentType;
            data.RuleType = temparyTable1.RuleType;
            data.Operator = temparyTable1.Operator;
            data.TableName = temparyTable1.TableName;
            data.ColumnName = temparyTable1.ColumnName;
            data.ArgValue1 = temparyTable1.ArgValue1;
            data.ArgValue2 = temparyTable1.ArgValue2;
            data.UiRule = temparyTable1.UiRule;
            data.EtlRule = temparyTable1.EtlRule;
            data.ErrorDescription = temparyTable1.ErrorDescription;
            data.RowCreatedBy = temparyTable1.RowCreatedBy;
            data.RowCreatedDate = temparyTable1.RowCreatedDate;
            data.RowChangedBy = temparyTable1.RowChangedBy;
            data.RowChangedDate = temparyTable1.RowChangedDate;
            data.RunOrder = temparyTable1.RunOrder;
            data.Severity = temparyTable1.Severity;
            data.RuleVersion = temparyTable1.RuleVersion;
            data.Expression = temparyTable1.Expression;
            data.InputArgV2 = temparyTable1.InputArgV2;
            data.ArgumentValue = temparyTable1.ArgumentValue;
            data.IsBre2 = temparyTable1.IsBre2;
            data.RuleRange = temparyTable1.RuleRange;
            await _service.PutAsync(data);
            return Ok(data);
        }
        [HttpPut("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            data.IsBre2 = false;


            await _service.DeleteAsync(data);
            return Ok(data);
        }




    }
}
