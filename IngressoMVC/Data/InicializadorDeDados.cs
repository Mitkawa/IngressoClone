using IngressoMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngressoMVC.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<IngressoDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema("PlayArte", "O Grupo PlayArte, ou apenas PlayArte, é uma empresa brasileira que atua nos ramos de distribuição e exibição cinematográfica, fundada nos anos 80 como a antiga VideoArte do Brasil.", "https://www.abcdacomunicacao.com.br/wp-content/uploads/cine-playarte-680x470.jpg"),
                        new Cinema("Cineflix", "A Cineflix é uma rede brasileira de cinemas. Sediada na cidade de Maringá atualmente está presente em dezesseis cidades das regiões centro oeste, sul e sudeste do país.", "https://www.cineflix.com.br/wp-content/themes/cineflix/images/cineflix-logo.png"),
                        new Cinema("Cinépolis", "A Cinépolis é uma rede multinacional de cinemas, com a sede brasileira na cidade de São Paulo e originária do México.", "https://pbs.twimg.com/profile_images/1547573782448984064/ssvFFnp-_400x400.jpg"),
                        new Cinema("Cinemark", "Cinemark é uma das três maiores redes de cinema do mundo. É uma empresa transnacional especializada em operar complexos cinematográficos multiplex.", "http://www.atoupeira.com.br/wp-content/uploads/2017/07/Cinemark-logo-Anime.jpgg")
                    });
                    context.SaveChanges();
                }

                if (!context.Atores.Any())
                {
                    context.Atores.AddRange(new List<Ator>()
                    {
                        new Ator("Robert Downey Jr.", "Robert John Downey, Jr. (nascido em 4 de abril de 1965) é um ator americano. Downey fez sua estréia na tela em 1970, aos cinco anos de idade, quando apareceu no filme de seu pai, Pound, e trabalhou consistentemente no cinema e na televisão desde então. Durante a década de 1980, ele teve papéis em uma série de filmes de amadurecimento associados ao Brat Pack.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg"),
                        new Ator("Henry Cavill", "Cavill nasceu em Jersey, e foi educado na Escola Preparatória St. Michael, na ilha, antes de frequentar a Stowe School, um internato, onde ele atuou em vários jogos.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/hErUwonrQgY5Y7RfxOfv8Fq11MB.jpg"),
                        new Ator("Gal Gadot", "Gal Gadot é uma atriz e modelo israelense. Ela nasceu em Rosh Ha'ayin, Israel, para uma família de judeus asquenazes (da Polônia, Áustria, Alemanha e Tchecoslováquia). Ela serviu no IDF por dois anos e ganhou o título de Miss Israel em 2004.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/plLfB60M5cJrnog8KvAKhI4UJuk.jpg"),
                        new Ator("Morgan Freeman", "Morgan Porterfield Freeman Jr, conhecido como Morgan Freeman, é um premiado ator, produtor, narrador, e diretor de cinema, nasceu dia 1 de junho de 1937, em Memphis, Tennessee, Estados Unidos da América. Ele é filho de Mayme Edna, uma professora e de Morgan Porterfield Freeman, um barbeiro.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/905k0RFzH0Kd6gx8oSxRdnr6FL.jpg"),
                        new Ator("Tim Robbins", "Timothy Francis 'Tim' Robbins (nascido em 16 de outubro de 1958) é um ator americano, roteirista, diretor, produtor, ativista e músico. Ele é o antigo parceiro de longa data da atriz Susan Sarandon. Ele é conhecido por seus papéis como Nuke em Bull Durham, Andy Dufresne em The Shawshank Redemption e Dave Boyle no Mystic River, pelo qual ele ganhou o Oscar de Melhor Ator Coadjuvante.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/hsCu1JUzQQ4pl7uFxAVFLOs9yHh.jpg"),
                        new Ator("Christian Bale", "Christian Charles Philip Bale é um ator britânico. Em 2011, ele venceu Oscar de Melhor Ator Coadjuvante, o Globo de Ouro de Melhor Ator Coadjuvante e o SAG Award de Melhor Ator Coadjuvante pela atuação como Dicky Eklund na cinebiografia The Fighter.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/qCpZn2e3dimwbryLnqxZuI88PTi.jpg"),
                        new Ator("Heath Ledger", "Heathcliff Andrew 'Heath' Ledger foi um ator australiano. Foi selecionado como um dos 100 melhores atores de todos os tempos pelo site Cinema Archives e venceu o Oscar de Melhor Ator Secundário pela sua atuação como Coringa, em O Cavaleiro Das Trevas, de Christopher Nolan.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/5Y9HnYYa9jF4NunY9lSgJGjSe8E.jpg"),
                        new Ator("Uma Thurman", "Uma Karuna Thurman (born April 29, 1970) is an American actress, writer, producer and model. She has acted in a variety of films, from romantic comedies and dramas to science fiction and action films. Following her appearances on the December 1985 and May 1986 covers of British Vogue, Thurman's breakthrough role was Dangerous Liaisons (1988) in which she starred.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/pGyACejvvLI6tB0gFQ2rCjwqKvd.jpg"),
                    });
                    context.SaveChanges();
                }

                if (!context.Produtores.Any())
                {
                    context.Produtores.AddRange(new List<Produtor>()
                    {
                        new Produtor("Christopher Nolan", "Christopher Edward Nolan ( /ˈnoʊlən/; Londres, 30 de julho de 1970) é um diretor de cinema, roteirista e produtor britânico. Seus nove longas-metragens já arrecadaram o equivalente a mais de 4,2 bilhões de dólares em todo o mundo, fazendo do diretor um dos mais bem-sucedidos comercialmente da moderna Hollywood.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/xuAIuYSmsUzKlUMBFGVZaWsY3DZ.jpg"),
                        new Produtor("Martin Scorsese", "Martin Scorsese (Martin Scorsese, Queens, Nova Iorque, 17 de novembro de 1942) é um cineasta, produtor de cinema, roteirista e ator norte-americano.", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/9U9Y5GQuWX3EZy39B8nkk4NY01S.jpg"),
                        new Produtor("Tim Burton", "Timothy Walter Burton (born August 25, 1958) is an American filmmaker, artist, writer, and animator. He is known for his dark, gothic, and eccentric horror and fantasy films such as Beetlejuice (1988), Edward Scissorhands (1990), Ed Wood (1994), Sleepy Hollow (1999), Corpse Bride (2005), Sweeney Todd: The Demon Barber of Fleet Street (2007), Dark Shadows (2012), and Frankenweenie (2012).", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/gRM4lGpiBINAyiXaxEeJFDKzmge.jpg")
                    });
                    context.SaveChanges();
                }

                if (!context.Categorias.Any())
                {
                    context.Categorias.AddRange(new List<Categoria>()
                    {
                        new Categoria("Ação"),
                        new Categoria("Aventura"),
                        new Categoria("Cinema de arte"),
                        new Categoria("Chanchada"),
                        new Categoria("Comédia"),
                        new Categoria("Dança"),
                        new Categoria("Documentário"),
                        new Categoria("Docuficção"),
                        new Categoria("Drama"),
                        new Categoria("Espionagem"),
                        new Categoria("Faroeste"),
                        new Categoria("Fantasia"),
                        new Categoria("Ficção científica"),
                        new Categoria("Mistério"),
                        new Categoria("Musical"),
                        new Categoria("Romance"),
                        new Categoria("Terror"),
                        new Categoria("TeThrillerrror")
                    });
                    context.SaveChanges();
                }

                if (!context.Filmes.Any())
                {
                    context.Filmes.AddRange(new List<Filme>()
                    {
                        new Filme("Liga da Justiça", "Impulsionado pela restauração de sua fé na humanidade e inspirado pelo ato altruísta do Superman, Bruce Wayne convoca sua nova aliada Diana Prince para o combate contra um inimigo ainda maior, recém-despertado. ", 20, "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/geyu6rplpbp7OUeOfB2uRVf1LpG.jpg", 1, 1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(10)),
                        new Filme("Sherlock Holmes: O Jogo de Sombras", "Watson está prestes a se casar com a sua amada Mary Morstan. Porém, a única coisa com que ele não contava era que seu amigo Holmes apareceria com uma nova teoria conspiratória de que o professor Moriarty estaria por trás de uma série de assassinatos.", 20, "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/of8oht9uENwEdx35HehEPUhGC2w.jpg", 2, 2, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(15)),
                        new Filme("Batman: O Cavaleiro das Trevas Ressurge", "Após ser culpado pela morte de Harvey Dent e passar de herói a vilão, Batman desaparece. As coisas mudam com a chegada de uma ladra misteriosa, a Mulher-Gato, e Bane, um terrorista mascarado, que fazem Batman abandonar seu exílio forçado.", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zRwO5BPPgkTNo1PoomZPE7wkKvQ.jpg", 3, 3, DateTime.Now.AddDays(1), DateTime.Now.AddDays(20)),
                        new Filme("Pulp Fiction: Tempo de Violência", "Vincent Vega (John Travolta) e Jules Winnfield (Samuel L. Jackson) são dois assassinos profissionais que trabalham fazendo cobranças para Marsellus Wallace (Ving Rhames), um poderosos gângster. Vega é forçado a sair com a garota do chefe, temendo passar dos limites. Enquanto isso, o pugilista Butch Coolidge (Bruce Willis) se mete em apuros por ganhar uma luta que deveria perder.", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/tptjnB2LDbuUWya9Cx5sQtv5hqb.jpg", 1, 4, DateTime.Now.AddDays(15), DateTime.Now.AddDays(30)),
                        new Filme("Um Sonho de Liberdade", "Em 1946, Andy Dufresne, um banqueiro jovem e bem sucedido, tem a sua vida radicalmente modificada ao ser condenado por um crime que nunca cometeu, o homicídio de sua esposa e do amante dela. Ele é mandado para uma prisão que é o pesadelo de qualquer detento, a Penitenciária Estadual de Shawshank, no Maine.", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/umX3lBhHoTV7Lsci140Yr8VpXyN.jpg", 1, 4, DateTime.Now.AddDays(15), DateTime.Now.AddDays(30)),
                        new Filme("Mulher-Maravilha", "Treinada desde cedo para ser uma guerreira imbatível, Diana Prince (Gal Gadot) nunca saiu da paradisíaca ilha em que é reconhecida como Princesa das Amazonas", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ujQthWB6c0ojlARk28NSTmqidbF.jpg", 1, 2, DateTime.Now.AddDays(-15), DateTime.Now.AddDays(5)),
                        new Filme("Batman & Robin", "A dupla dinâmica enfrenta os supervilões Mr. Freeze e sedutora ecoterrorista Hera Venenosa. Mas, para poder livrar Gotham City das garras dos vilões, Batman e Robin contam com uma nova companheira, a Batgirl.", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/cGRDufDDSrFrv7VI4YnmWnslne0.jpg", 2, 2, DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-5)),
                        new Filme("10 Coisas Que Eu Odeio em Você", "Em seu primeiro dia na nova escola, Cameron se apaixona por Bianca. Mas ela só poderá sair com rapazes até que Kat, sua irmã mais velha, arrume um namorado. O problema é que ela é insuportável. Cameron, então, negocia com o único garoto que talvez consiga sair com Kat – um misterioso bad-boy com uma péssima reputação.", 20, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/6WImK7UIRY7fZ0l9UwnxbP74w1p.jpg", 3, 3, DateTime.Now.AddDays(-28), DateTime.Now.AddDays(-9))
                    });
                    context.SaveChanges();
                }

                if (!context.FilmesCategorias.Any())
                {
                    context.FilmesCategorias.AddRange(new List<FilmeCategoria>()
                    {
                        new FilmeCategoria(1, 1),
                        new FilmeCategoria(1, 2),
                        new FilmeCategoria(1, 3),
                        new FilmeCategoria(2, 2),
                        new FilmeCategoria(2, 4),
                        new FilmeCategoria(2, 5),
                        new FilmeCategoria(3, 7),
                        new FilmeCategoria(4, 8),
                        new FilmeCategoria(5, 9),
                        new FilmeCategoria(6, 3),
                        new FilmeCategoria(7, 2),
                        new FilmeCategoria(8, 1),
                        new FilmeCategoria(8, 3),
                        new FilmeCategoria(8, 5)
                    });
                    context.SaveChanges();
                }

                if (!context.AtoresFilmes.Any())
                {
                    context.AtoresFilmes.AddRange(new List<AtorFilme>()
                    {
                        new AtorFilme(7, 1),
                        new AtorFilme(8, 2),
                        new AtorFilme(2, 3),
                        new AtorFilme(1, 4),
                        new AtorFilme(5, 4),
                        new AtorFilme(8, 5),
                        new AtorFilme(1, 6),
                        new AtorFilme(6, 6),
                        new AtorFilme(7, 6),
                        new AtorFilme(4, 7),
                        new AtorFilme(2, 8),
                        new AtorFilme(3, 8)
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
