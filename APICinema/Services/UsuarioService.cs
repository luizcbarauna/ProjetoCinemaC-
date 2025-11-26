using APICinema.Data;
using APICinema.DTOS;
using APICinema.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICinema.Services
{
    public class UsuarioService
    {
        private readonly CinemaContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(CinemaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsuarioDto> FindByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return _mapper.Map<UsuarioDto?>(usuario);
        }
        public async Task<UsuarioDto> CriarUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            
            if (await _context.Usuarios.AnyAsync(x => x.Email == usuarioDto.Email))
                throw new Exception("Email já está cadastrado.");
            if (await _context.Usuarios.AnyAsync(x => x.Cpf == usuarioDto.Cpf))
                throw new Exception("CPF já está cadastrado.");
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioDto>(usuario);
        }
    }
}
