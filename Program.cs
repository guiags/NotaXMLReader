using NotaXMLReader.src.NotaXMLReader.Application;
using System.Xml;
namespace NotaXMLReader
{
    class Program
    {
        static void Main(string[] args)
        {
            String URLString = "C:/Users/guilh/Documents/Projects/NotaXMLReader/notas/notaxml.xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            if (reader.Read() == false)
            {
                Console.WriteLine("Não pegou nada");
            }

            var notaxml = new NotaXML();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "nNF")
                {
                    notaxml.NumeroNota = reader.ReadElementString();
                    //Console.WriteLine($"Número da Nota: {notaxml.NumeroNota}");
                }

                // Itens da NF
                var fimitens = false;
                var itemNF = new ItemNotaXML();
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "det")
                {
                    itemNF.nItem = reader.GetAttribute("nItem");
                    //Console.WriteLine($"Número do Item: {itemNF.nItem}");
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "valor")
                {
                    fimitens = true;
                }
                if (!fimitens)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "NCM")
                    {
                        itemNF.Ncm = Int32.Parse(reader.ReadElementString());
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "CEST")
                    {
                        itemNF.Cest = Int32.Parse(reader.ReadElementString());
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "CFOP")
                    {
                        itemNF.Cfop = Int32.Parse(reader.ReadElementString());
                        notaxml.ItemNotaXMLs.Add(itemNF);
                    }
                }
            }
            Console.WriteLine($"Nota Fiscal:{notaxml.NumeroNota}");
            for(int i = 0; i<notaxml.ItemNotaXMLs.Count(); i++)
            {
                Console.WriteLine($"NCM:{notaxml.ItemNotaXMLs[i].Ncm}   CEST:{notaxml.ItemNotaXMLs[i].Cest}   CFOP:{notaxml.ItemNotaXMLs[i].Cfop}   ST:{notaxml.ItemNotaXMLs[i].TipoItem}");
            }

        }
    }
}