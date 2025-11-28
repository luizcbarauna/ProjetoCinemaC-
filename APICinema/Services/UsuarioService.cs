using APICinema.Data;
using APICinema.DTOS;
using APICinema.Model;
using APICinema.Model.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var usuario = await _context.Usuarios.Include(x=>x.Endereco).FirstOrDefaultAsync(x=>x.Id == id);
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
        public async Task<List<UsuarioBuscaDto>> BuscarTodosAsync()
        {
            return await _context.Usuarios.Select(x=> new UsuarioBuscaDto
            {
               Id = x.Id,
               Cpf = x.Cpf,
               Email = x.Email,
               NomeCompleto = x.NomeCompleto
            }).ToListAsync();
        }
      public async Task<bool> DeletarUsuarioAsync(int  id)
        {
            var usuario = await _context.Usuarios.Include(e=> e.Endereco).FirstOrDefaultAsync(x=> x.Id ==id);
            if(usuario == null)return false;

             _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioEditarDto obj)
        {
            var usuario = await _context.Usuarios.Include(e=> e.Endereco)
                                .FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)throw new Exception("Usuário não encontrado");
            try
            {
                _mapper.Map(obj, usuario);
                usuario.DataAtualizacao = DateTime.Now;
                await _context.SaveChangesAsync();
                return _mapper.Map<UsuarioDto>(usuario);
            }
            catch (Exception ex)
            { throw new Exception(ex.ToString()); }


        }
       
    }
}
