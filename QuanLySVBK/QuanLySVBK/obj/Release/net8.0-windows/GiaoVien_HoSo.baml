   M S B A M L   `   `   `  ����   
QuanLySVBK    QuanLySVBK.GiaoVien_HoSo   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     PrimaryButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value  HeaderTextStyle  ReadOnlyTextBoxStyle  EditableTextBoxStyle
 �� BasedOn��%+  &	        &	 i    &	 �    &	 �    7  �� " ��.���  � �� �#2196F3��  � ��
 �������  � �� �#1976D2��  � ��$ 1q���  �@�Cursor$
 Hand����  � ��$ SemiBold"���  � ��$
 10,5q���  � �� �� " ��.R��� #��z��#��z��#��z��$ 5��# z��._��� $��Center=�$��Center=� P�  � ��$
	 True��. ���  � �� �#1976D2�� " ��.���  � ��$
 Bold"���  � ��$ Center=���  � ��$	 120����  � ��$ 0,0,10,0q��� " ��.���  � ��$ 32����  � ��$ Center=���  �@��
IsReadOnly$
 True����  � �� �#FAFAFA��  � �� �#DDD��  � ��$ 1q���  � ��$ 5q���  � ��$	 0,5q��� " ��8
   .���  �@��
IsReadOnly$ False����  � ��
 �����.���� ���#F0F0F0$ 10��$ 20q�._��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��2��$��HỒ SƠ GIẢNG VIÊN��$��18(�$
��Bold"�$��Center=�$��0,0,0,20q����#1976D2�� $��1��$��0��$��
Họ tên:��#��[ �� -    ��Name$ TxtHoTen��$��1��$��1��#��[ �� $��2��$��0��$��Ngày sinh:��#��[ �� -   $ TxtNgaySinh��$��2��$��1��#��[ �� $��3��$��0��$��Giới tính:��#��[ �� -   $ TxtGioiTinh��$��3��$��1��#��[ �� $��4��$��0��$��Quê quán:��#��[ �� -   $ 
TxtQueQuan��$��4��$��1��#��[ �� $��5��$��0��$��Viện:��#��[ �� -   $ TxtVien��$��5��$��1��#��[  �� TextWrapping$
 Wrap=��� $��6��$��0��$��Email:��#��[ �� -   $ TxtEmail��$��6��$��1��#��[ �� $��7��$��0��$��Số điện thoại:��#��[ �� -   $ TxtSoDienThoai��$��7��$��1��#��[ �� $��8��$��0��$��CCCD:��#��[ �� -   $ TxtCCCD��$��8��$��1��#��[ �� $��10��$��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -	    ��Name$ BtnHuy��$��Hủy��$��90��#��[  $��0,0,10,0q�$y�	Collapsed=��� -
   $ BtnLuu��$
��Lưu��$��90��#��[  ���#4CAF50���#388E3C$y�	Collapsed=��� -   $ BtnChinhSua��$��Chỉnh sửa��$	��100��#��[  