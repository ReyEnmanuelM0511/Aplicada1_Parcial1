using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using PrimerParcial.Models;
using System.Linq.Expressions;
using PrimerParcial.Context;

namespace PrimerParcial.Services;

public class AutoresServices(IDbContextFactory<Contexto> contextFactory) : IService<Autores, int>
{
    public async Task<bool> Existe (int IdAutor)
    {
        using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.autores.m
        
    }

    public async Task<bool> Insertar(int IdAutor)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        await contexto.AddAsync(IdAutor);
        return await contexto.autores.(a => a.IdAutor == IdAutor).SaveChangesAsync();
    }        
    

    public async Task<bool> Guardar(Autores autores)
    {
        if(!await Existe(autores.IdAutor))
        {
            return await Insertar(autores.IdAutor);
        }
        else
        {
            return await Modificar(autores);
        }
    }

    public async Task<bool> Modificar (Autores autores)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(autores);
        return await contexto..SaveChangesAsync();
    }
    
    public async Task<List<Autores>> GetList(Expression<Func<AutoresServices>> criterio)
    {

    }
}