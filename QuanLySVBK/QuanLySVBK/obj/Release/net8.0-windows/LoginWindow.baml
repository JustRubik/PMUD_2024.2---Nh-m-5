   M S B A M L   `   `   `  ����   
QuanLySVBK    QuanLySVBK.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Aav2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Đăng nhập�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � WindowState$ 	Maximized=�
������ $	��400��$	��550��.��� .+�� .+��� $.��(Images/background_man_hinh_dang_nhap.jpg��$
��Fill=��� ���	#CCF02A2A� $��50q� � RowDefinitions �� $��* ��� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* �.+��� $��1��$��1��$	��300��$	��400�� �� Padding$ 20q�
������� �� CornerRadius$ 10��$��Center=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ._��� .+��� $��Đăng nhập��$
��Bold"�$��24(�$��Center=�$
��0,10q��� $"��Images/logo_dai_hoc_bkhn.PNG��$	��100��$��Center=�$
��0,10q��� $��
Bạn là:��$��12(�$��0,10,0,5q��� 	 �� Orientation$	 
Horizontal=�$��Center=�.+�	� -   
 	�Name$
 
AdminRadio��$��Admin�� 	� 	GroupName$
 Role��$
��10,0q�	� -   $
 StudentRadio��$��
Sinh viên��$
 Role��$
��10,0q�	� -   $
 TeacherRadio��$��Giảng viên��$
 Role��$
��10,0q��� $��Tài khoản��$��12(�$��0,10,0,0q�]� .+��� $��Images/icon-user.png��$��16��$��16��$��0,0,5,0q��� -    ��Name$ UsernameBox�� � ToolTip$* $Vui lòng nhập email đăng nhập��$
��Auto���� $��Mật khẩu��$��12(�$��0,10,0,0q�]� .+��� $��Images/icon-lock.png��$��16��$��16��$��0,0,5,0q�G� -    G�Name$ PasswordBox��$# Vui lòng nhập mật khẩu��$
��Auto���� -    ��Name$ ForgotPassword��$��Quên mật khẩu?��$��10(�$��Right=�$��0,5,0,0q�
������� � Cursor$
 Hand���� -    ��Name$ LoginButton��$��ĐĂNG NHẬP��$��40��$
��Bold"����#9CABF5
�������$��0q�$��0,20,0,0q�$
 Hand�� �� 	IsDefault$
 True������  �� 
TargetType" ��.R���  ��Name$ border��#��z��$ 20��#��z��#��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ border�� �� Property � �� �� Value �#7A93F7P�  � ��$
 True��. ��� $ border�� � �� �#5A75E6P�  � {�$ False��. ��� $ border�� � �� �#CCC��  � ��
 �����