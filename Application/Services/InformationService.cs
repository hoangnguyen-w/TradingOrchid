using Application.Common.Dto.Comment;
using Application.Common.Dto.Exception;
using Application.Common.Dto.Information;
using Application.Common.Dto.Page;
using Application.Common.Dto.User;
using Application.Interfaces.Comments;
using Application.Interfaces.Informations;
using Application.Interfaces.Users;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InformationService : IInformationService
    {
        private readonly IInformationRepository informationRepository;
        private readonly IMapper mapper;
        public InformationService
            (IInformationRepository informationRepository, IMapper mapper)
        {
            this.informationRepository = informationRepository;
            this.mapper = mapper;
        }

        public async Task<List<InformationViewDTO>> GetAll(PageDto page)
        {
            try
            {
                var information = mapper.Map<List<InformationViewDTO>>(await informationRepository.GetAll(page));
                return information;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> GetByID(int id)
        {
            try
            {
                var information = mapper.Map<List<InformationViewDTO>>(await informationRepository.GetByID(id));
                return information;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }

        public async Task<List<InformationViewDTO>> Search(string search)
        {
            try
            {
                var information = mapper.Map<List<InformationViewDTO>>(await informationRepository.Search(search));
                return information;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message, 500);
            }
        }
    }
}
