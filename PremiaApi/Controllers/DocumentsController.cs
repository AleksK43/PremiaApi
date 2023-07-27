using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremiaApi.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using PremiaApi.Controllers.Models;
using PremiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;

namespace PremiaApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly PremiaDbContext dbContext;

        public DocumentsController(PremiaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            return Ok(await dbContext.documents.ToListAsync());
        }

        [HttpGet]
        [Route("single/{documentId:guid}")]
        public async Task<IActionResult> GetDocument(Guid documentId)
        {
            var document = await dbContext.documents.FindAsync(documentId);

            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpGet]
        [Route("{invoiceOwner:guid}")]
        public async Task<IActionResult> GetAllUserDocuments([FromRoute] Guid invoiceOwner)
        {
            var documents = await dbContext.documents
                                       .Where(document => document.InvoiceOwner == invoiceOwner)
                                       .ToListAsync();

            if (!documents.Any())  
            {
                return NotFound();
            }
            return Ok(documents);
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(AddDocumentRequest addDocumentRequest)
        {
            var documents = new Documents()
            {
                Id = Guid.NewGuid(),
                Customer = addDocumentRequest.Customer,
                InvoiceNumber = addDocumentRequest.InvoiceNumber,
                Type = addDocumentRequest.Type,
                InvoiceOwner = addDocumentRequest.InvoiceOwner,
                CaseNumber = addDocumentRequest.CaseNumber,
                Income = addDocumentRequest.Income,
                TimeConsuming = addDocumentRequest.TimeConsuming,
                Drive = addDocumentRequest.Drive,
                Month = addDocumentRequest.Month,
                InvoiceStatus = addDocumentRequest.InvoiceStatus,
                CreateDate = addDocumentRequest.CreateDate,
                NewInvoice = addDocumentRequest.NewInvoice = true,
                PreAccept = addDocumentRequest.PreAccept = false,
                Accepted = addDocumentRequest.Accepted = false
                
            };
            documents.CreateDate = DateTime.Now;
            await dbContext.documents.AddAsync(documents);
            await dbContext.SaveChangesAsync();

            return Ok(documents);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDocument([FromRoute] Guid id, DocumentUpdateRequest documentUpdateRequest)
        {
            var document = await dbContext.documents.FindAsync(id);
            if (document != null)
            {
                document.Customer = documentUpdateRequest.Customer;
                document.InvoiceNumber = documentUpdateRequest.InvoiceNumber;
                document.Type = documentUpdateRequest.Type;
                document.InvoiceOwner = documentUpdateRequest.InvoiceOwner;
                document.CaseNumber = documentUpdateRequest.CaseNumber;
                document.Income = documentUpdateRequest.Income;
                document.TimeConsuming = documentUpdateRequest.TimeConsuming;
                document.Drive = documentUpdateRequest.Drive;
                document.Month = documentUpdateRequest.Month;
                document.InvoiceStatus = documentUpdateRequest.InvoiceStatus;
                document.ModifyDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
                return Ok(document);
            }
            return NotFound();
        }



        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDocument([FromRoute] Guid id)
        {
            var document = await dbContext.documents.FindAsync(id);

            if (document != null)
            {
                dbContext.Remove(document);
                await dbContext.SaveChangesAsync();
                return Ok("This User Was Deleted");
            }

            return NotFound();

        }


    }
}

