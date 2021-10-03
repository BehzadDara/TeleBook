using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeleBook.Application.Contracts;
using TeleBook.Domain.Enums;
using TeleBook.Domain.Interfaces;
using TeleBook.Domain.Models;
using TeleBook.Domain.Specifications;

namespace TeleBook.Application.Services
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StudentAppService: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tele> _repository;

        public StudentAppService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Tele> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        
        [HttpPost("Tele")]
        public async Task<IActionResult> CreateTele(TeleCreateDto input)
        {    
            if (input.Gender != GenderType.Man.ToString() && input.Gender != GenderType.Woman.ToString())
            {
                return BadRequest(new ResponseDto(Error.GenderError));
            }
            var myTele = _mapper.Map<Tele>(input);
            _repository.Add(myTele);
            await _unitOfWork.CompleteAsync();
            
            return Ok(_mapper.Map<TeleDto>(myTele));
        }  
        
        [HttpPut("Tele")]
        public async Task<IActionResult> UpdateTele(Guid id, TeleUpdateDto input)
        {
            var myTele = await _repository.GetByIdAsync(id);
            if (myTele is null)
            {
                return NotFound(new ResponseDto(Error.TeleNotFound));
            }
            
            if(!string.IsNullOrEmpty(input.FirstName)) 
                myTele.FirstName = input.FirstName;
            if(!string.IsNullOrEmpty(input.LastName)) 
                myTele.LastName = input.LastName;
            if (!string.IsNullOrEmpty(input.Gender))
            {
                if (input.Gender != GenderType.Man.ToString() && input.Gender != GenderType.Woman.ToString())
                {
                    return BadRequest(new ResponseDto(Error.GenderError));
                }
                myTele.Gender = (GenderType) Enum.Parse(typeof(GenderType), input.Gender, true);
            }
            if(!string.IsNullOrEmpty(input.NationalCode)) 
                myTele.NationalCode = input.NationalCode;
            if(!string.IsNullOrEmpty(input.Telephone)) 
                myTele.Telephone = input.Telephone;
            if(!string.IsNullOrEmpty(input.Address)) 
                myTele.Address = input.Address;
            if(input.SpecTag.HasValue) 
                myTele.SpecTag = input.SpecTag.Value;
            
            
            _repository.Update(myTele);
            await _unitOfWork.CompleteAsync();
            return Ok(_mapper.Map<TeleDto>(myTele));
        }  
        
        [HttpDelete("Tele")]
        public async Task<IActionResult> DeleteTele(Guid id)
        {
            var myTele = await _repository.GetByIdAsync(id);
            if (myTele is null)
            {
                return NotFound(new ResponseDto(Error.TeleNotFound));
            }

            await _repository.DeleteAsync(myTele.Id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }  
        
        [HttpGet("Tele")]
        public async Task<IActionResult> GetTele(Guid id)
        {
            var myTele = await _repository.GetByIdAsync(id);
            if (myTele is null)
            {
                return NotFound(new ResponseDto(Error.TeleNotFound));
            }
            
            return Ok(_mapper.Map<TeleDto>(myTele));
        }   
        
        [HttpGet("Tells")]
        public async Task<IActionResult> GetTells()
        {
            var myTells = await _repository.ListAllAsync();
            
            var myTellsDto = _mapper.Map<IList<TeleDto>>(myTells);
            var myTellsListDto = new EntityListDto<TeleDto>
            {
                Entities = myTellsDto,
                TotalCount = myTellsDto.Count
            };
            return Ok(myTellsListDto);
        }  
        
        [HttpGet("Tells/SpecTag")]
        public async Task<IActionResult> GetTellsBySpecTag(bool specTag)
        {
            var myTells = await _repository.ListAsync(new GetTeleBySpecTag(specTag));
            
            var myTellsDto = _mapper.Map<IList<TeleDto>>(myTells);
            var myTellsListDto = new EntityListDto<TeleDto>
            {
                Entities = myTellsDto,
                TotalCount = myTellsDto.Count
            };
            return Ok(myTellsListDto);
        }
        
        
    }
}