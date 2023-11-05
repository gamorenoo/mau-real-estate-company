using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Login
{
    public class LoginQuery : IRequest<bool>
    {
        public UserDto User { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, bool>
    {
        private readonly IMapper _mapper;

        public LoginQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userIdValid = request.User.Email.Equals("gustavoamoreno@outlook.com") && request.User.Password.Equals("0123456789");

            return userIdValid;
        }
    }
}
