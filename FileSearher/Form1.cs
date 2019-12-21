using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;



namespace FileSearher
{
    

    public partial class Form1 : Form
    {
        private static bool is_pause = false; // если нажата пауза, то true
        private static bool is_work = false; // если поиск не работает или нажат "сброс", то false
        static ManualResetEvent _event; // событие для остановки search_files потока
        Thread search_files; // поиск и вывод файлов в дереве
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Start_Pause_Click(object sender, EventArgs e)
        {
            if (!is_work)
            {
                is_work = true;
                search_files = new Thread(new ParameterizedThreadStart(AuxiliaryCreateDirectoryNode));
                Start_Pause.Text = "Пауза";
                _event = new ManualResetEvent(true);

                // ограничиваю возможность изменения формы
                path_label.Enabled = false;
                filename_label.Enabled = false;
                content_label.Enabled = false;

                string path = path_box.Text;
                string filename_pattern = filename_box.Text;
                string contain_str = content_box.Text;

                var rootDirectoryInfo = new DirectoryInfo(path);
                if (filename_pattern == "")
                    filename_pattern = "*";
                if (contain_str == "")
                    contain_str = null;

                // использую вспомогательный класс, чтобы перекинуть все атрибуты в поток
                AuxiliaryClassObject auxiliary_class_object = new AuxiliaryClassObject();
                auxiliary_class_object.directoryInfo = rootDirectoryInfo;
                auxiliary_class_object.filename_pattern = filename_pattern;
                auxiliary_class_object.contain_str = contain_str;

                // запускаю поток
                search_files.Start(auxiliary_class_object);
            }
            else if(is_work && !is_pause)
            {
                Start_Pause.Text = "Пуск";
                is_pause = true;
                // событие остановки работы потока
                _event.Reset();
            }
            else if (is_work && is_pause)
            {
                Start_Pause.Text = "Пауза";
                is_pause = false;
                // событие продолжения работы потока
                _event.Set();
            }

        }

        private void AuxiliaryCreateDirectoryNode(object auxiliary_class_object)
        {
            // вспомогательный метод,чтобы перебросить все атрибуты в метод CreateDirectoryNode из auxiliary_class_object
            AuxiliaryClassObject x = (AuxiliaryClassObject)auxiliary_class_object;
            int count_of_processed_files = 0;
            FindFiles(x.directoryInfo, x.filename_pattern, x.contain_str, count_of_processed_files);
        }

        private int FindFiles(DirectoryInfo directoryInfo, string filename_pattern, string contain_str, int count_of_processed_files)
        {
            
            _event.WaitOne();
            
            // проходит по всем каталогам
            foreach (var directory in directoryInfo.GetDirectories())
                try
                {
                    // проходит по всем каталогом внутри каталогов
                    count_of_processed_files = FindFiles(directory, filename_pattern, contain_str, count_of_processed_files
);
                }
                catch (System.UnauthorizedAccessException expt)
                {
                    // обработка исключения на случай, если не хватает прав, чтобы зайти в каталог
                }
            // проходит по всем файлам внутри каталога
            foreach (var file in directoryInfo.GetFiles(filename_pattern))
            {
                _event.WaitOne();
                count_of_processed_files++;
                Action action = () =>
                {
                    current_file_label.Text = file.Name;
                    count_of_files_label.Text = count_of_processed_files.ToString();
                };
                Invoke(action);

                try
                {
                    // нужно ли читать файл?
                    if (contain_str != null)
                    {
                        // читает файл, находит совпадения
                        if (File.ReadAllText(file.FullName).Contains(contain_str))
                        {
                            CreateNode(file.FullName.Split('\\'), 0);
                        }
                    }
                    else
                    {
                        CreateNode(file.FullName.Split('\\'), 0);
                    }
                    
                }
                catch (System.IO.IOException excpt)
                {
                    // обработка исключения на случай, если не хватает прав, чтобы прочитать файл
                }
            }
            return count_of_processed_files;
        }

        private void CreateNode(string[] file_path, int deep, TreeNodeCollection cur_node = null)
        {
            // метод, которое передаётся основному потоку на добавления узла в дереве.
            Action action = () => cur_node.Add(file_path[deep], file_path[deep]);

            // проверка, последнюю ли часть file_path мы читаем (чтобы не выйти за пределы массива)
            if (deep != file_path.Length-1)
            {
                // если данный узел не известен, то вписывать в корень дерева
                if (cur_node == null)
                    cur_node = treeView1.Nodes;

                int i = cur_node.IndexOfKey(file_path[deep]);
                // если нет такого узла, то i = -1
                if (i >= 0)
                {
                    // создаём следующий узел
                    deep++;
                    CreateNode(file_path, deep, cur_node[i].Nodes);
                }
                else
                {
                    if (InvokeRequired)
                    {
                        // передаёт основному потоку метод, для добавления нового узла
                        Invoke(action);
                    }
                    else
                    {
                        action();
                    }
                    deep++;
                    CreateNode(file_path, deep, cur_node[cur_node.Count - 1].Nodes);
                }
            }
            else
            {
                if (InvokeRequired)
                {
                    Invoke(action);
                }
                else
                {
                    action();
                }
            }
        }

        private void path_butt_Click(object sender, EventArgs e)
        {
            // открывает проводник для выбора начального пути
            using(FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    path_box.Text = fbd.SelectedPath;
            }
        }

        private void dropping_bt_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Start_Pause.Text = "Пуск";
            is_work = false;
            current_file_label.Text = "";
            count_of_files_label.Text = "";

            // должен прерывать процесс
            search_files.Abort();

            // очистка всей памяти
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    public class AuxiliaryClassObject
    {
        public DirectoryInfo directoryInfo;
        public string filename_pattern;
        public string contain_str;
    }
}

