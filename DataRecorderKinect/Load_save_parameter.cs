using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace DataRecorderKinect
{
	class Load_save_parameter
	{
		private string default_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
		private string path_parameter_list = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + @"\path_parameter_list.txt";

		private List<string[]> parameter_list = new List<string[]>();

		Form1 target;

		public Load_save_parameter(Form1 form)
		{
			target = form;

			if (!Directory.Exists(default_folder))
				System.IO.Directory.CreateDirectory(default_folder);

			if (File.Exists(path_parameter_list))
			{
				parameter_list = ReadFromBinaryFile<List<string[]>>(path_parameter_list);
			}

			foreach (string[] item in parameter_list.Reverse<string[]>())
			{
				string temp_path = default_folder + "\\" + item[0];

				if (File.Exists(temp_path))
				{
					try
					{
						var temp_res = ReadFromBinaryFile(temp_path, item[1]);
						typeof(Form1).GetField(item[0]).SetValue(form, temp_res); // sætter værdien på variablen
					}
					catch (Exception e)
					{
						int d = 5;

						// missing 
					}
				}
				else
				{
					int delete_index = parameter_list.FindIndex(x => x[0] == item[0]);
					parameter_list.RemoveAt(delete_index);
				}
			}
		}

		public void save_variable<T>(Expression<Func<string, T>> f)
		{
			string var_name = (f.Body as MemberExpression).Member.Name; // får navnet på variablen 

			T var_val = (T)typeof(Form1).GetField(var_name).GetValue(target); /// henter værdigen
			Type myType = typeof(T);
			string[] temp_data = new string[] { var_name, myType.FullName + ", " + myType.Assembly.FullName };

			int index = parameter_list.FindIndex(x => x[0] == temp_data[0]);

			if (index == -1)
			{
				parameter_list.Add(temp_data);
				WriteToBinaryFile(path_parameter_list, parameter_list);
			}

			string temp_path = default_folder + "\\" + var_name;
			WriteToBinaryFile(temp_path, var_val);

		}

		public object LoadObjectFromFile(string varname)
		{
			// ikke færdig
			int d = 5;
			var bla = (Type.GetType("System.UInt16"));

			var sf = (Activator.CreateInstance(bla));
			sf = 5;

			int ds = 5;

			return null;
		}

		public void SaveObjectAsNewFile<T>(Expression<Func<string, T>> f)
		{
			string var_name = (f.Body as MemberExpression).Member.Name; // får navnet på variablen 
			string temp_path = default_folder + "\\" + var_name;


			if (!Directory.Exists(temp_path))
			{
				Directory.CreateDirectory(temp_path);
			}

			string SavePathForFile = "";
			int count = 0;
			do
			{
				count++;
				SavePathForFile = temp_path + "\\" + var_name + count;
			} while (File.Exists(SavePathForFile));


			List<string[]> InternalParameterList = null;

			if (File.Exists(temp_path + @"\InternalParameterList.txt"))
			{
				InternalParameterList = ReadFromBinaryFile<List<string[]>>(temp_path + @"\InternalParameterList.txt");
			}
			else
			{
				InternalParameterList = new List<string[]>();
			}

			T var_val = (T)typeof(Form1).GetField(var_name).GetValue(target); /// henter værdigen
			Type myType = typeof(T);
			string[] temp_data = new string[] { var_name + count, myType.FullName + ", " + myType.Assembly.FullName };

			parameter_list.Add(temp_data);
			WriteToBinaryFile(temp_path + @"\InternalParameterList.txt", InternalParameterList);

			WriteToBinaryFile(SavePathForFile, var_val);

		}

		private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
		{
			using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}
		}

		private static T ReadFromBinaryFile<T>(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				return (T)binaryFormatter.Deserialize(stream);
			}
		}

		private static object ReadFromBinaryFile(string filePath, string var_type)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

				return Convert.ChangeType(binaryFormatter.Deserialize(stream), Type.GetType(var_type));
			}
		}
	}
}
