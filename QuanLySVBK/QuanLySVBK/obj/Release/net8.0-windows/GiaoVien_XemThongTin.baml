   M S B A M L   `   `   `  ����   
QuanLySVBK%    QuanLySVBK.GiaoVien_XemThongTin   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     PrimaryButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value �� 
TargetName �� ScaleX �� ScaleY  EditButtonStyle �� BasedOn3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth   Opacity  StandardTextBoxStyle��%�  &	        &	 �    7   &	 �    �� " ��.���  � �� �#2196F3��  � ��
 �������  � �� �#1976D2��  � ��$ 1q���  �@�Cursor$
 Hand����  � ��$ SemiBold"���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 5��# z��._��� $��Center=�$��Center=� P� 	 � ��$

 True��. ��� $ border�� � �� �#1976D2�� $ border�� � z� �� $
 0.97Q�$
 0.97Q��� $ border�� �@J�RenderTransformOrigin$ 0.5,0.5&��� " ��8   .���  � �� �#FF9800��  � �� �#FB8C00��  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 5��# z��._��� $��Center=�$��Center=� P� 	 �@J�IsMouseOver$

 True��. ��� $ border�� � �� �#f57c00�� $ border�� �@J�Effect   $ Black��$ 8Q�$ 2Q�$	 0.2Q�P� 	 � ��$

 True��. ��� $ border�� � �� �#e65100�� " ��.���  � ��$ 20����  � ��$ Center=�.���� ���#F0F0F0$ 10��$ 15q�._��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��Mã sinh viên:��$	��100��$
��Bold"�$��Center=��� -    ��Name$ TxtMaSinhVien��$	��150��$��5,0,20,0q�#��[ �� $��Tên sinh viên:��$	��100��$
��Bold"�$��Center=��� -   $ TxtTenSinhVien��$	��250�� �� 
IsReadOnly$
 True�����#EEE#��[ �� $��1��$ 
Horizontal=�$��0,0,0,10q�.+��� $��
Mã lớp:��$	��100��$
��Bold"�$��Center=��� -   $ TxtMaLop��$	��150��$��5,0,20,0q�#��[ �� $��Kì học hiện tại:��$	��100��$
��Bold"�$��Center=��� -    ��Name$ CboKiHoc��$	��120��$��5,0,20,0q� �� SelectedIndex$ 0��$��32��.@��� $��20223���� $��20222���� $��20221���� -    ��Name$ BtnLoc��$��90��$	��8,0q�$��5,0,0,0q�#��[  .���� $ 
Horizontal=�$��Center=�.+��� $
��🔍��$��14(�$��0,0,5,0q��� $��Lọc��&   System.Windows.Controls.DataGrid  -     Name$ 
dgThongTin��$��2��   AutoGenerateColumns$ False�����#F0F0F0���#CCC$��1q�$
��Auto=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã môn��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MaMon+  $ 	Tên môn��$ *  �� *TenMon+  $ Số tín chỉ��$ 80  �� *
SoTinChi+  $ Điểm��$ 80  �� *Diem+�� -   $ BtnSuaThongTin��$��3��$��Right=�$��	0,15,20,0q�$
��10,5q�$	��130��#��[ .���� $ 
Horizontal=�$��Center=�.+��� $��✏️��$��14(�$��0,0,5,0q��� $��Sửa thông tin��