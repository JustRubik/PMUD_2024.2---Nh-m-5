   M S B A M L   `   `   `  ����   
QuanLySVBK    QuanLySVBK.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Màn hình chính�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � WindowState$ 	Maximized=�$	��700��$	��980�� � 	Resources    MainMenuHeaderTextBlock �� 
TargetType �� Property �� Value  SubMenuItemStyle �� Triggers	 P� Property
 P� Value  PopupButtonStyle��%P  &	        &	 v     &	 �    �� " ��.���  � ��
 �������  � ��$ 17(���  � ��$ SemiBold"���  �@��Padding$	 0,4q��� " m�.���  � ��
 ���� ��  � ��
 ��  ���  � ��$
 10,4q���  � ��$ 16(���  � ��$ Normal"� P� 	 �@J�IsMouseOver$

 True��. ���  � �� �#D0E7FF��  � ��
 ��  �P� 	 �@m�	IsPressed$

 True��. ���  � �� �#D0E7FF��  � ��
 ��  ��� " ��.���  � ��
 ���� ��  � ��
 ��  ���  � ��$
 10,4q���  � ��$ 16(���  � ��$ Normal"���  �@�Cursor$
 Hand����  � ��$ 0q���  � ��$
 Left=� P� 	 �@J�IsMouseOver$

 True��. ���  � �� �#D0E7FF��  � ��
 ��  �P� 	 � ��$

 True��. ���  � �� �#A0C5FF��  � ��
 ��  �.��]� .+�� ���#e62c2c$	��Top=�$	��118�� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $"��Images/logo_dai_hoc_bkhn.png��$��99��$��	15,5,10,5q�$��Center=�$��0����  �� Orientation$ Vertical=�$��Center=�$
��20,0q�$��1��.+��� $'��!ĐẠI HỌC BÁCH KHOA HÀ NỘI��$��26(�
�������$
��Bold"��� $(��"HỆ THỐNG QUẢN LÝ SINH VIÊN��$��19(�
�������� $��2��$��Right=�$��Center=�$��0,0,20,0q�.+��� -    ��Name$ AccountButton��$��60��$��40��$
��Bold"�$��24(�
������ 
�������$��0q� � Cursor$
 Hand������  �� 
TargetType" ��.R���  ��Name$ border��#��z�� �� CornerRadius$ 20��#��z��#��z��._��� $��/Images/icon-user.png��$��Uniform=�$��Center=�$��Center=� �� Triggers P� 	 �@J�IsMouseOver$

 True��. ���  �� 
TargetName$ border�� � �� �#F05555P� 	 � ��$

 True��. ��� $ border�� � �� �#C03333� -    �Name$ SubMenuPopup_Account��$��Right=� � 	StaysOpen$ False�� � AllowsTransparency$
 True��$
��Fade=� � PlacementTarget ��  �� ElementName$ AccountButton��.���� 
�������$ 5�� �� Padding$ 10q�._��� .+��� -   $��Tài khoản��#��[ �� -   $��Cài đặt��#��[ �� -   $��Đăng xuất��#��[ o� $	��Top=�
���   �$��34��.@�m� -   $��	20,0,20,0q����� $��TRANG CHỦ��#��[  m� $��0,0,20,0q����� $��
DANH MỤC��#��[  .@�m� -   $��Danh mục giảng viên��#��[ m� -   $��Danh mục sinh viên��#��[ m� -	   $��Danh mục học phần��#��[ m� -
   $��Danh mục khoa viện��#��[ m� -   $#��Danh mục lớp học phần��#��[ m� -   $#��Danh mục ngành đào tạo��#��[ m� $��0,0,20,0q����� $��XỬ LÝ ĐIỂM��#��[  .@�m� -   $��Xử lý CPA��#��[ m� -   $��Xử lý GPA��#��[ m� -   $.��(Xử lý điểm tổng kết môn học��#��[ m� -   $��0,0,20,0q����� $��CẬP NHẬT ĐIỂM��#��[  m� $��0,0,20,0q����� $��THỐNG KÊ��#��[  .@�m� $��Thống kê theo kì��#��[ m� $��Thống kê theo khóa��#��[ m� $0��*Thống kê sinh viên đạt học bổng��#��[ m� -   $��0,0,20,0q����� $��TRỢ GIÚP��#��[  � -    �Name$ MainContentArea��.+��� $4��.Images/dither_it_background_man_hinh_chinh.jpg��$
��Fill=��� -    ��Name$ MainContentControl��