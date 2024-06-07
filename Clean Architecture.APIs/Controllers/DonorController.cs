﻿using Clean_Architecture.Application.DTOs.DonorDTOs;
using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly DonorService donorService;

        public DonorController(DonorService donorService)
        {
            this.donorService = donorService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetAllDonors()
        {
            List<showDonorDTO> donorDTOs = await donorService.GetDonors();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = donorDTOs

            };

        }

        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetDonorById(int id)
        {
            var donor = donorService.GetDonorById(id);
            if (donor == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "Donor not Found"
                };

            }
            else
            {
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = donor


                };
            }

        }

        [HttpGet("badge")]
        public async Task<ActionResult<GeneralResponse>> GetAllDonorsWithBadges()
        {
            List<showDonorWithBadgeDTO> donorDTOs = await donorService.GetDonorsWithBadges();
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = donorDTOs

            };

        }

        [HttpPost]
        public ActionResult<GeneralResponse> InsertDonor(addDonorDTO addDonorDTO)
        {
            if (ModelState.IsValid)
            {
                donorService.AddDonor(addDonorDTO);

                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = addDonorDTO
                };
            }
            return new GeneralResponse
            {
                IsPass = false,
                Status = 400,
                Message = "unable to add new donor"
            };

        }

        [HttpPut]
        public ActionResult<GeneralResponse> UpdateDonor(updateDonorDTO updateDonorDTO)
        {
            donorService.UpdateDonor(updateDonorDTO);
            var donor = donorService.GetDonorById(updateDonorDTO.id);
            return new GeneralResponse
            {
                IsPass = true,
                Status = 200,
                Message = donor
            };
        }


        [HttpDelete]
        public ActionResult<GeneralResponse> DeleteDonor(int id)
        {

            var donor = donorService.GetDonorById(id);
            if (donor == null)
            {
                return new GeneralResponse
                {
                    IsPass = false,
                    Status = 404,
                    Message = "Donor not found"
                };
            }
            else
            {
                donorService.DeleteDonor(id);
                return new GeneralResponse
                {
                    IsPass = true,
                    Status = 200,
                    Message = donor.Name + " delete successfully"
                };
            }
        }

    }
}