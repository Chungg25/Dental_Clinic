
using Dental_Clinic.BUS.Admin;
using Dental_Clinic.DTO.Admin;
using Dental_Clinic.GUI.Administrator;
using System.Diagnostics;

namespace Dental_Clinic.GUI.QuanTriVien.NguoiDung
{
    public partial class FormFaceID : Form
    {
        private MainForm mainForm;
        private QuanTriVienDTO quanTriVienDTO;
        private QuanTriVienBUS quanTriVienBUS;
        private Process pythonProcess;
        private StreamWriter pythonInput;
        public FormFaceID(MainForm mainForm, QuanTriVienDTO userDTO)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            quanTriVienDTO = userDTO;
            quanTriVienBUS = new QuanTriVienBUS();
            a();
        }

        private async void StartPythonProcess()
        {
            if (pythonProcess == null || pythonProcess.HasExited)  // Kiểm tra tiến trình
            {
                string filePath = Path.Combine(Application.StartupPath, "real-time-face-recognition", "face_taker.py");
                string basePath = Path.Combine(Application.StartupPath, "real-time-face-recognition");
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    
                    FileName = "python",
                    //Arguments = "D:\\real-time-face-recognition\\face_taker.py",
                    Arguments = $"{filePath} {basePath}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                };

                try
                {
                    pythonProcess = new Process();
                    pythonProcess.StartInfo = psi;

                    // Xử lý đầu ra không đồng bộ
                    pythonProcess.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Xử lý đầu ra
                            // Ví dụ: MessageBox.Show("Kết quả: " + e.Data);
                        }
                    };

                    pythonProcess.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Xử lý lỗi
                            MessageBox.Show("Lỗi: " + e.Data);
                        }
                    };

                    pythonProcess.Start();
                    pythonInput = pythonProcess.StandardInput;  // Giữ stream input để gửi dữ liệu đến Python

                    pythonProcess.BeginOutputReadLine();  // Bắt đầu đọc đầu ra
                    pythonProcess.BeginErrorReadLine();    // Bắt đầu đọc lỗi

                    int faceId = quanTriVienDTO.Id; // Lấy faceId từ quanTriVienDTO

                    if (pythonInput != null)
                    {
                        pythonInput.WriteLine($"{faceId}");  // Gửi face_id và face_name đến Python
                    }

                    // Đợi tiến trình face_taker.py kết thúc
                    await Task.Run(() => pythonProcess.WaitForExit());

                    string filePath1 = Path.Combine(Application.StartupPath, "real-time-face-recognition", "face_train.py");
                    string basePath1 = Path.Combine(Application.StartupPath, "real-time-face-recognition");
                    // Gọi file face_train.py để huấn luyện mô hình
                    ProcessStartInfo trainPsi = new ProcessStartInfo
                    {
                        FileName = "python",
                        //Arguments = "D:\\real-time-face-recognition\\face_train.py",  // Đường dẫn đến face_train.py
                        Arguments = $"{filePath1} {basePath1}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    };

                    Process trainProcess = new Process();
                    trainProcess.StartInfo = trainPsi;

                    trainProcess.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Xử lý đầu ra huấn luyện
                            // Ví dụ: MessageBox.Show("Huấn luyện: " + e.Data);
                        }
                    };

                    trainProcess.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // Xử lý lỗi huấn luyện
                            MessageBox.Show("Lỗi huấn luyện: " + e.Data);
                        }
                    };

                    trainProcess.Start();
                    trainProcess.BeginOutputReadLine();  // Bắt đầu đọc đầu ra
                    trainProcess.BeginErrorReadLine();    // Bắt đầu đọc lỗi

                    // Đợi tiến trình huấn luyện hoàn tất
                    await Task.Run(() => trainProcess.WaitForExit());

                    // Đóng stream input và tiến trình
                    pythonInput?.Close();
                    pythonProcess?.Close();
                    trainProcess?.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }



        private async void a()
        {
            StartPythonProcess();
        }
    }
}
