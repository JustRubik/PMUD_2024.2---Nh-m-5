﻿using System.Windows;
using QuanLySVBK.Accounts;
using QuanLySVBK.DBHelpers;

namespace QuanLySVBK
{
    public partial class MainWindow : Window
    {
        public bool isLoggingOut;
        private readonly LoginWindow loginWindow;
        private readonly string _username;
        private readonly string _role;
        private readonly string _id;
        private string? _name;

        public MainWindow(string username, string id, string role, LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            _username = username;
            _id = id;
            _role = role;

            Title = "Đang tải thông tin...";
            Task.Run(() =>
            {
                string? name = UserHelper.GetFullName(username, id, role);
                Dispatcher.Invoke(() => Title = $"Xin chào {name}");
                _name = name;
            });
        }

        private void Homepage_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = null;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            SubMenuPopup_Account.IsOpen = !SubMenuPopup_Account.IsOpen;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student")
            {
                TaiKhoanSinhVien taiKhoanSinhVien = new(_name, _id);
                MainContentControl.Content = taiKhoanSinhVien;
            }
            else if (_role == "lecturer")
            {
                TaiKhoanGiangVien taiKhoanGiangVien = new(_name, _id);
                MainContentControl.Content = taiKhoanGiangVien;
            }
            else return;
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HandleGPA_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyGPA();
        }

        private void HandleCPA_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyCPA();
        }

        private void HandleFinalGrade_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student" || _role == "lecturer")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new XuLyDiemTongKet();
        }

        private void UpdateScoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "student")
                MessageBox.Show("Bạn không có quyền truy cập");
            else
                MainContentControl.Content = new CapNhatDiem();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new HelpWindow();
        }

        private void DanhMucGiangVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucGiangVien(_role);
        }

        private void DanhMucSinhVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucSinhVien(_role);
        }

        private void DanhMucHocPhan_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucHocPhan(_role);
        }

        private void DanhMucNganhDaoTao_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucNganhDaoTao(_role);
        }

        private void DanhMucLopHocPhan_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucLopHocPhan(_role);
        }

        private void DanhMucKhoaVien_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new DanhMucKhoaVien(_role);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            isLoggingOut = true;
            loginWindow.Show();
            Application.Current.MainWindow = loginWindow;
            Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoggingOut && Application.Current.MainWindow == this)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát?",
                    "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result != MessageBoxResult.Yes)
                    e.Cancel = true;
            }
        }

    }
}
