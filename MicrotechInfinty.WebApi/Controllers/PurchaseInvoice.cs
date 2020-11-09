using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicrotechInfinity.Domain.Entities;
using MicrotechInfinity.Domain.Interfaces;
using MicrotechInfinity.Domain.Interfaces.UoW;
using MicrotechInfinity.Domain.Services;
using MicrotechInfinity.WebApi.XFer;

namespace MicrotechInfinity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoiceController : ControllerBase
    {
        private readonly IPurchaseInvoiceRepository pInvoiceRepo;
        private IUnitOfWork unitOfWork;
        public PurchaseInvoiceController(IPurchaseInvoiceRepository pInvoiceRepository, IUnitOfWork unitOfWork)
        {
            this.pInvoiceRepo = pInvoiceRepository;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pInvoiceServise = new PurchaseInvoiceService(pInvoiceRepo, unitOfWork);
            var data = await pInvoiceServise.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }


        [HttpPost]
        public ActionResult<string> Page()
        {
            try
            {
                GridViewRequest gvReq = new GridViewRequest(); 
                gvReq.Parse(Request.Form);


                GridResponse<MDPurchaseInvoice> fl = new GridResponse<MDPurchaseInvoice>();
                var pInvoiceServise = new PurchaseInvoiceService(pInvoiceRepo, unitOfWork);

                Int64 totalRows = 0;
                var invoices = pInvoiceServise.GetPage(gvReq.DispStart, gvReq.DispLength, gvReq.ColSort, gvReq.ColFilters, out totalRows);

                fl.sEcho = 1;
                fl.iTotalRecords = gvReq.DispLength;
                fl.iTotalDisplayRecords = totalRows;
                fl.Data = invoices.ToList();

                return fl.GetJson();
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
