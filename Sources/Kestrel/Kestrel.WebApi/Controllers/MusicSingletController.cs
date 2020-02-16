using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Kestrel.DataAccess.Tools;
using Kestrel.EntityModel.Music;
using Kestrel.ViewModelServices;
using Kestrel.WebApi.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel.MusicVM;

namespace Kestrel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class MusicSingleController : BaseTemplateController<MusicSingle, MusicSingleVM>
    {

        private readonly IWebAPIModelService<MusicSingle, MusicSingleVM> _service;

        /// <summary>
        /// 构造函数,一般负责通过注入相关变量初始化控制器的标量
        /// </summary>
        /// <param name="context">控制器使用的 DbContext</param>
        public MusicSingleController(
               IWebAPIModelService<MusicSingle, MusicSingleVM> service
            )
        {
            this._service = service;
        }

        /// <summary>
        /// 获取所有的 MusicSingle 对象，前端访问定义 GET: api/MusicSingle
        /// </summary>
        /// <returns>以 json 集合方式返回集合元素数据</returns>
        [HttpGet]
        public Task<List<MusicSingleVM>> GetMusicSingles()
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }

        public Task<List<MusicSingleVM>> GetMusicSingles(String Token)
        {
            var VM = _service.GetBoVMCollectionAsyn();

            return VM;
        }
        [HttpPost]
        public async Task<ActionResult<MusicSingleVM>> PostMusicSingle(MusicSingleVM MusicSingleVM) 
        {
            var saveStatus = new SaveStatusModel() { SaveSatus = true, Message = "" };
            await _service.SaveBoAsyn(MusicSingleVM);
            return CreatedAtAction(nameof(GetMusicSingles), new { id = MusicSingleVM.ID }, MusicSingleVM);
        }

        /// <summary>
        /// 根据指定的 id 获取对应的 MusicSingle  对象，前端访问定义  GET: api/MusicSingle/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>指定 id 对应的 User 对象</returns>
        [HttpGet("{id}")]  // 这里直接将方法的路由再做一次定义 api/MusicSingle/id
        public async Task<ActionResult<MusicSingleVM>> GetMusicSingle(Guid id)
        {
            var VM = _service.GetBoVMAsyn(id);


            if (VM == null)
            {
                return NotFound(); // 返回 404
            }

            return await VM;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetMusicSingle(Guid id, MusicSingleVM MusicSingleVM)
        {

            var Commodity = await _service.GetBoVMAsyn(id);
            if (Commodity != null)
            {
                await _service.SaveBoAsyn(MusicSingleVM);

            }
            return NoContent(); // 返回 204
        }



        /// <summary>
        /// 接受前端以 DELETE 方式提交的请求，根据请求的 id ，删除数据集合中相应的 Commodity 对象，
        /// 前端访问定义 DELETE: api/MusicSingle/id
        /// </summary>
        /// <param name="id">待删除的对象的 id</param>
        /// <returns>删除的对象的数据</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicSingleVM>> DelMusicSingle(Guid id)
        {
            var CommodityVM = await _service.GetBoVMAsyn(id);
            if (CommodityVM == null)
            {
                return NotFound(); // 返回 404
            }
            await _service.DeleteBoAsyn(id);

            return CommodityVM;
        }
    }
}
