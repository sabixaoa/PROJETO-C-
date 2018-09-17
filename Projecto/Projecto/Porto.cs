using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projecto
{
    [Serializable()]
    public class Porto 
    {

        private ArrayList _navios;
        private ArrayList _navioscontentores;
        private ArrayList _contentores;
        private int _ultimonavio;
        private int _ultimocontentor;

        public Porto()
        {
            _navios = new ArrayList();
            _navioscontentores = new ArrayList();
            _contentores = new ArrayList();
            _ultimocontentor = 0;
            _ultimonavio = 0;
        }

        public int UltimoNavio
        {
            get => _ultimonavio;
            set => _ultimonavio = value;
        }

        public int UltimoContentor
        {
            get => _ultimocontentor;
            set => _ultimocontentor = value;
        }

        public ArrayList Navios
        {
            get => _navios;
            set => _navios = value;
        }

        public ArrayList NaviosContentores
        {
            get => _navioscontentores;
            set => _navioscontentores = value;
        }

        public ArrayList Contentores
        {
            get => _contentores;
            set => _contentores = value;
        }
        

        public void AdicionarContentores()
        {


            Console.WriteLine("\nIntroduza o destino:");
            string destino = Console.ReadLine();
            Console.WriteLine("\nIntroduza o tipo( basico, explosivo our quimico) :");
            string tipo = Console.ReadLine();
            if (tipo == "basico" || tipo == "Basico")
            {
                Console.WriteLine("\nIntroduza a descricao:");
                string descricao = Console.ReadLine();
                Console.WriteLine("\nIntroduza se é  refrigerado(true our false:\n");
                bool refrigerado = Convert.ToBoolean(Console.ReadLine());
                new Basico(descricao, refrigerado);
            }
            if (tipo == "explosivo"||tipo=="Explosivo")
            {
                Console.WriteLine("\nIntroduza o tipo de explosivo:");
                string tipoexplosivo = Console.ReadLine();
                Console.WriteLine("\nIntroduza se é de plástico (true our false:\n");
                bool plastico = Convert.ToBoolean(Console.ReadLine());
                new Explosivo(tipoexplosivo, plastico);
            }
            if (tipo == "quimico" || tipo == "Quimico")
            {
                Console.WriteLine("\nIntroduza a descricao:");
                string tipoquimico = Console.ReadLine();
                new Quimicos(tipoquimico);
            }
            Console.WriteLine("\n\nIntroduza o Peso:");
            int peso = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\nO contentor foi adicionado com sucesso! \n");
            UltimoContentor++;
            _contentores.Add(new Contentor(destino, tipo, peso));
        }

        public void RemoverContenor()
        {
            if (_contentores.Count == 0)
            {
                Console.WriteLine("\n\nNão existem contentores");
                return;
            }

            foreach (Contentor c in _contentores)
            {
                Console.WriteLine(c.Numero);
                Console.WriteLine("---------------");
            }

            int x;
            Console.WriteLine("\n\nPor favor introduza o nº do contentor que quer remover: \n");
            x = Convert.ToInt32(Console.ReadLine());
            foreach (Contentor c in _contentores)
            {


                if (c.Numero == x)
                {
                    Console.WriteLine("\n\nO contentor Nº" + x + " foi removido com sucesso! \n");
                    _contentores.Remove(c);
                    return;
                }

                else
                {
                    Console.WriteLine("\n\nO nº de navio não existe! \n");
                    return;
                }

            }

        }

        public bool AdcionarNavio()
        {
            string nome;
            int _MaxContentores, _MaxExplosivos, _MaxQuimicos;
            bool estado;

            Console.WriteLine("\n\nPor Favor Insira o nome do navio: \n");

            nome = Console.ReadLine();
            Console.WriteLine("\n\nintroduza o estado do navio(true our false): \n");

            string tmp = Console.ReadLine();
            estado = (tmp == "true" || tmp == "True") ? true : false;

            Console.WriteLine("\n\nIntroduza o número máximo de contentores que o navio suporta: \n");

            _MaxContentores = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("\n\nIntroduza o número máximo de contentores quimicos que o navio suporta: \n");
                _MaxQuimicos = Convert.ToInt32(Console.ReadLine());
                if (_MaxQuimicos > _MaxContentores)
                {
                    Console.WriteLine("\n\nErro, o nº de contentores quimicos excede o nº total de contentores");
                }

            } while (_MaxQuimicos > _MaxContentores);


            do
            {
                Console.WriteLine("\n\nIntroduza o número máximo de contentores explosivos que o navio suporta: \n");
                _MaxExplosivos = Convert.ToInt32(Console.ReadLine());
                if (_MaxExplosivos > _MaxContentores)

                {
                    Console.WriteLine("\n\nErro, o nº de contentores explosivos excede o nº total de contentores");
                }

                if (_MaxQuimicos + _MaxExplosivos > _MaxContentores)
                {
                    Console.WriteLine("\n\nErro, o nº de contentores quimicos + explosivos excede o nº total de contentores");
                }

            } while (_MaxExplosivos > _MaxContentores || _MaxQuimicos + _MaxExplosivos > _MaxContentores);

            Console.WriteLine("navio adicionado com sucesso\n\n");
            Navio n1 = new Navio(nome, estado, _MaxContentores, _MaxExplosivos, _MaxQuimicos);
            if (_navios.Add(n1) >= 0)
            {
                UltimoNavio++;
                return true;                
            }
                

            return false;
        }

        public void listarnavios()
        {
            foreach (Navio n in _navios)
            {
                Console.WriteLine("\n-----------------------------\n");
                Console.WriteLine(n);
                    
            }
        }



            public void Adicionarcontentornavio()
            {
                Console.WriteLine("\n\nIntroduza o numero do contentor:");
                int numContentor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n\nIntroduza o numero do navio onde pretende introduzir o contentor:");
                int numNavio = Convert.ToInt32(Console.ReadLine());
                foreach (Navio n in _navios)
                {
                    if (n.Numero == numNavio)
                    {

                        foreach (Contentor c in _contentores)
                        {
                            if (c.Numero == numContentor)
                            {
                                c.Numero_Navio = numNavio;
                                n.Contentores.Add(c);

                                Console.WriteLine("\n\ncontentor" + numContentor + " foi adicionado com sucesso ao Navio" + numNavio);
                                return;
                            }
                        }
                        Console.WriteLine("\n\nO contentor " + numContentor + " não existe");
                        return;
                    }
                    Console.WriteLine("\n\nO navvio " + numNavio + " não existe");
                    return;

                }
                Console.WriteLine("\n-------------------------------------------");


            }   

        public void removercontentornavio()
        {
            Console.WriteLine("\n\nIntroduza o numero do contentor que pertende remover:");
            int numContentor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\nIntroduza o numero do navio onde pretende remover o contentor:");
            int numNavio = Convert.ToInt32(Console.ReadLine());
            foreach (Navio n in _navios)
            {
                if (n.Numero == numNavio)
                {

                    foreach (Contentor c in _contentores)
                    {
                        if (c.Numero == numContentor)
                        {
                            n.Contentores.Remove(c);
                            Console.WriteLine("\n\ncontentor" + numContentor + "foi removido com sucesso ao Navio" + numNavio);
                            return;
                        }
                    }
                    Console.WriteLine("\n\nO contentor " + numContentor + " não existe");
                    return;
                }

            }
            Console.WriteLine("\n\nO navvio " + numNavio + " não existe");
            return;


        }
        public void ListarContentorsemnavio(bool condicao)
        {
            if (_contentores == null || _contentores.Count == 0)
            {
                return;
            }

            foreach (Contentor c in _contentores)
            {
                if ((c.Numero_Navio == 0) == condicao)
                {
                    Console.WriteLine(c);
                }

                Console.WriteLine("\n---------------");


            }


            return;

        }
        public void listarcontentoresnavio()
        {
            if (_navios == null || _navios.Count == 0)
            {
                return;
            }
            Console.WriteLine("\n\nIntroduza o numero do navio :");
            int numNavio = Convert.ToInt32(Console.ReadLine());
            foreach (Navio n in _navios)
            {
                foreach (Contentor c in n.Contentores)
                {
                    Console.WriteLine(c);
                }


                Console.WriteLine("\n---------------");


            }
            Console.WriteLine("\n-------------------------------------------");
            return;

        }

        public void ListarNavio()
        {


            foreach (Navio s in _navios)
            {
                if (_navios.Count == 0)
                {
                    Console.WriteLine("\n\nNão existem navios");
                }
                Console.WriteLine(s);
                Console.WriteLine("---------------");


            }
            Console.WriteLine("\n-------------------------------------------");
            return;
        }
        public void RemoverNavio()
        {
            if (_navios.Count == 0)
            {
                Console.WriteLine("\n\nNão existem navios");
                return;
            }

            foreach (Navio n in _navios)
            {
                Console.WriteLine(n.Numero);
                Console.WriteLine("---------------");
            }

            int x;
            Console.WriteLine("\n\nPor favor introduza o nº do navio que quer remover: \n");
            x = Convert.ToInt32(Console.ReadLine());
            foreach (Navio n in _navios)
            {


                if (n.Numero == x)
                {
                    Console.WriteLine("\n\nO navio Nº" + x + " foi removido com sucesso! \n");
                    _navios.Remove(n);
                    Console.WriteLine("\n-------------------------------------------");
                    return;
                }

                else
                {
                    Console.WriteLine("\n\nO nº de navio não existe! \n");
                    Console.WriteLine("\n-------------------------------------------");
                    return;
                }

            }
            Console.WriteLine("\n-------------------------------------------");

        }
        public int Estadonavio()
        {
            int contagem = 0;
            foreach (Navio n in _navios)
            {
                if (!n.Estado)
                    contagem++;
            }

            return contagem;
        }


        public void Guardar(Porto porto)
        {
            Stream stream = new FileStream("porto.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, porto);
            stream.Close();
        }
        public  Porto Carregar()
        {
            Stream stream = new FileStream("porto.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Porto porto = (Porto)formatter.Deserialize(stream);
            stream.Close();
            Navio.ultimo = porto.UltimoNavio;
            Contentor.ultimo = porto.UltimoContentor;
            return porto;
        }
        
    }
}
