   M S B A M L   `   `   `  ����   
QuanLySVBK%    QuanLySVBK.ForgotPasswordWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Aav2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  
QuanLySVBK�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � WindowState$ 	Maximized=�
������ .��� .+��� $.��(Images/background_man_hinh_dang_nhap.jpg��$
��Fill=��� ���	#CCF02A2A�� $	��350��$	��250��
������� �� CornerRadius$ 10��$��Center=�$��Center=� �� Padding$ 20q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ._��� .+�� $��0q�.+��� $"��Vui lòng nhập email để��$
��Bold"�$��24(�$��Center=�$
��Wrap=�� $��0,0,0,30q�.+��� $��lấy lại mật khẩu��$
��Bold"�$��24(�$��Center=�$
��Wrap=�]� .+��� $��Images/icon-user.png��$��16��$��16��$��0,0,5,0q��� -    ��Name$ EmailBox��$
��Auto�� � ToolTip$ Nhập email của bạn���� -   	 ��Name$	 
SendButton��$��GỬI��$	��200��$��40��$
��Bold"����#9CABF5
�������$��0q�$��0,20,0,0q�
 � Cursor$

 Hand������  �� 
TargetType" ��.R���  ��Name$ border��#��z��$ 20��#��z��#��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ border�� �� Property � �� �� Value �#7A93F7P�  � ��$
 True��. ��� $ border�� � �� �#5A75E6P�  � {�$ False��. ��� $ border�� � �� �#CCC��  � ��
 �����