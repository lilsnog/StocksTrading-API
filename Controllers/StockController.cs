using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly iStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, iStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

       [HttpGet]
       public async Task<IActionResult> GetAll() 
       {
            var stocks = await _context.Stocks.ToListAsync();//Defered Execution
                
            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
       }

       [HttpGet("{id}")]
       public  async Task<IActionResult> GetById([FromRoute] int id)
       {
            var stock = await _stockRepo.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
       }

       [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if(stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel =await _stockRepo.DeleteAsync(id);

            if(stockModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
    

    
}