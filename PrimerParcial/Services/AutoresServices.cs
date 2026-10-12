using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using PrimerParcial.Models;
using System.Linq.Expressions;
using PrimerParcial.Context;
using System.Runtime.InteropServices;

namespace PrimerParcial.Services;

public class AutoresServices(IDbContextFactory<Contexto> contextFactory) : IService<Autores, int>
{
    public async Task<bool> Existe(int IdAutor)
    {
        using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.autores.AnyAsync(e => e.IdAutor == IdAutor);

    }

    public async Task<bool> Insertar(Autores Autor)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        await contexto.AddAsync(Autor);
        return await contexto.SaveChangesAsync() > 0;
    }


    public async Task<bool> Guardar(Autores autores)
    {
        if (!await Existe(autores.IdAutor))
        {
            return await Insertar(autores);
        }
        else
        {
            return await Modificar(autores);
        }
    }

    public async Task<bool> Modificar(Autores autores)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(autores);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Autores?> Buscar (int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.autores.FirstOrDefaultAsync(a => a.IdAutor == id);
    }

    public async Task<List<Autores>> GetList(Expression<Func<Autores, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.autores.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.autores.Where(a => a.IdAutor == id).ExecuteDeleteAsync() > 0;
    }
}