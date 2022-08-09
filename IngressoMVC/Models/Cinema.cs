using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Cinema : IEntidade
    {
        public Cinema(string nome, string descricao, string logoURL)
        {
            Nome = nome;
            Descricao = descricao;
            LogoURL = logoURL;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
        }

        public int Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string LogoURL { get; private set; }

        public List<Filme> Filmes { get; set; }

        public void AtualizarDados(string nome, string descricao, string logoURL)
        {
            Nome = nome;
            Descricao = descricao;
            LogoURL = logoURL;

            DataAlteracao = DateTime.Now;
        }
    }
}
