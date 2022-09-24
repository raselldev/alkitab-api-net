using System;
using AlkitabAPI.External.Contracts;

namespace AlkitabAPI.Service
{
    public interface IPassage
    {
        Task<Root> Passage(string passage);
    }
}

