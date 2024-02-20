using System;
using System.Collections.Generic;
using System.Xml;

namespace T2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CBAPI.Code[] codes = CBAPI.GetCodes();
			for (int i = 0; i < codes.Length; i++)
			{
				Console.WriteLine(i + " - " + codes[i].Name);
			}
			int num = int.Parse(Console.ReadLine());
			Console.WriteLine(CBAPI.GetValue(codes[num >= 0 ? (num < codes.Length ? num : 0) : 0].ID, DateTime.Now).ToString());
			Console.ReadLine();
		}

		static class CBAPI
		{
			public static Сurrency GetValue(string code, DateTime date)
			{
				XmlDocument xDoc = new XmlDocument();
				
				xDoc.Load("https://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date.ToString("dd/MM/yyyy"));
				XmlElement xRoot = xDoc.DocumentElement;
				if (xRoot != null)
				{
					foreach (XmlElement xnode in xRoot)
					{
						XmlNode attr = xnode.Attributes.GetNamedItem("ID");

						if (attr.InnerText == code)
						{
							string ID = attr.InnerText;
							string NumCode = "";
							string CharCode = "";
							string Nominal = "";
							string Name = "";
							string Value = "";
							string VunitRate = "";
							foreach (XmlNode childnode in xnode.ChildNodes)
							{
								switch (childnode.Name)	
								{
									case "NumCode":
										NumCode = childnode.InnerText;
										break;
									case "CharCode":
										CharCode = childnode.InnerText;
										break;
									case "Nominal":
										Nominal = childnode.InnerText;
										break;
									case "Name":
										Name = childnode.InnerText;
										break;
									case "Value":
										Value = childnode.InnerText;
										break;
									case "VunitRate":
										VunitRate = childnode.InnerText;
										break;
									default:
										break;
								}
							}
							return new Сurrency(ID, NumCode, CharCode, Nominal, Name, Value, VunitRate);
						}
					}
				}
				return null;
			}

			public static Code[] GetCodes()
			{
				List<Code> codes = new List<Code>();
				XmlDocument xDoc = new XmlDocument();
				xDoc.Load("https://www.cbr.ru/scripts/XML_val.asp?d=0");
				XmlElement xRoot = xDoc.DocumentElement;
				if (xRoot != null)
				{
					foreach (XmlElement xnode in xRoot)
					{
						XmlNode attr = xnode.Attributes.GetNamedItem("ID");
						string id = attr.InnerText;
						string Name = "";
						string EngName = "";
						string Nominal = "" ;
						string ParentCode = "";

						foreach (XmlNode childnode in xnode.ChildNodes)
						{
							switch (childnode.Name)
							{
								case "Name":
									Name = childnode.InnerText;
									break;
								case "EngName":
									EngName = childnode.InnerText;
									break;
								case "Nominal":
									Nominal = childnode.InnerText;
									break;
								case "ParentCode":
									ParentCode = childnode.InnerText;
									break;
							}
							codes.Add(new Code(id, Name, EngName, Nominal, ParentCode));
						}
					}
				}
				return codes.ToArray();
			}
			public class Сurrency
			{
				public readonly string ID;
				public readonly string NumCode;
				public readonly string CharCode;
				public readonly string Nominal;
				public readonly string Name;
				public readonly string Value;
				public readonly string VunitRate;

				public Сurrency(string iD, string numCode, string charCode, string nominal, string name, string value, string vunitRate)
				{
					ID = iD;
					NumCode = numCode;
					CharCode = charCode;
					Nominal = nominal;
					Name = name;
					Value = value;
					VunitRate = vunitRate;
				}

				public override string ToString()
				{
					return
						   "\nID: " + ID
						+ "\nNumCode: " + NumCode
						+ "\nCharCode: " + CharCode
						+ "\nNominal: " + Nominal
						+ "\nName: " + Name
						+ "\nValue: " + Value
						+ "\nVunitRate: " + VunitRate;
				}
			}
			public class Code
			{
				public readonly string ID;
				public readonly string Name;
				public readonly string EngName;
				public readonly string Nominal;
				public readonly string ParentCode;

				public Code(string iD, string name, string engName, string nominal, string parentCode)
				{
					ID = iD;
					Name = name;
					EngName = engName;
					Nominal = nominal;
					ParentCode = parentCode;
				}
			}
		}
	}
}
