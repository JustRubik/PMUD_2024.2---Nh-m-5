   M S B A M L   `   `   `  ����  
QuanLySVBK    QuanLySVBK.LoginWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Aav2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Đăng nhập��5       � WindowStartupLocation$ CenterScreen=�5	       � WindowStyle$ SingleBorderWindow=�5
       � WindowState$ 	Maximized=�5      
������ $	��400��5      $	��550��6   .��5      � .+�5   
   � .+�5      �� $.��(Images/background_man_hinh_dang_nhap.jpg��6   $
��Fill=�6F   �� 5      ���	#CCF02A2A6   5      � 5   
   $��50q�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5       $��* �6#   .+�5$      �� $��1��6   $��1��6"   $	��300��5%      $	��400��6$    �� Padding$ 20q�5&      
������� �� CornerRadius$ 10��5(      $��Center=�5)      $��Center=�5*       J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,      ._�5/      �� .+�50      �� $��Đăng nhập��6    $
��Bold"�61   $��24(�6C   $��Center=�51       $
��0,10q�6=   �� 54      $"��Images/logo_dai_hoc_bkhn.PNG��6   $	��100��55      $��Center=�56      $
��0,10q�69   �� 59      $��
Bạn là:��6    $��12(�6/   $��0,10,0,5q�6=   �� 5:      	 �� Orientation$	 
Horizontal=�6!   $��Center=�6:   .+�5;      	� -   5        
 	�Name$
 
AdminRadio��5;   &   $��Admin��6:    	� 	GroupName$
 Role��6J   $
��10,0q�6[   	� 5<      -   5        $
 StudentRadio��5<   &   $��
Sinh viên��6<   $
 Role��6P   $
��10,0q�6a   	� 5=      -   5        $
 TeacherRadio��5=   &   $��Giảng viên��6<   $
 Role��6Q   $
��10,0q�6b   5>      �� 5A      $��Tài khoản��6    $��12(�61   $��0,10,0,0q�6?   ]� 5B      .+�5C      �� $��Images/icon-user.png��6    $��16��6>   $��16��6I   $��0,0,5,0q�6U   �� 5D      -   5         ��Name$ UsernameBox��5D   "    � ToolTip$* $Vui lòng nhập email đăng nhập��67   $
��Auto��6_   5E      �� 5H      $��Mật khẩu��6    $��12(�60   $��0,10,0,0q�6>   ]� 5I      .+�5J      �� $��Images/icon-lock.png��6    $��16��6>   $��16��6I   $��0,0,5,0q�6U   G� 5K      -   5         G�Name$ PasswordBox��5K   &   $# Vui lòng nhập mật khẩu��6;   $
��Auto��6\   5L      �� 5O      -   5         ��Name$ ForgotPassword��5O       $��Quên mật khẩu?��68   $��10(�6N   $��Right=�5P       $��0,5,0,0q�6<   
������� � Cursor$
 Hand��5Q   2   5R       �� 5U      -   5         ��Name$ LoginButton��5U      $��ĐĂNG NHẬP��62   $��40��6F   $
��Bold"�5V      ���#9CABF5
�������$��0q�5W      $��0,20,0,0q�61   $
 Hand��5X   7    �� 	IsDefault$
 True��6E   ��5Y      �� 5Z       �� 
TargetType" ��6.   .R�5[   "   ��  ��Name$ border��6)   #��z��5\   )   $ 20��5]   )   #��z��5^   )   #��z��5_   )   ._�5`   &   �� $��Center=�67   $��Center=�6T   5a   #    �� Triggers 5b   "   P� 5c   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5d   *   ��  �� 
TargetName$ border��61    �� Property � �� �� Value �#7A93F76[   5e   '   P� 5f   &    � ��$
 True��6C   . �5g   *   �� $ border��61    � �� �#5A75E66[   5h   '   P� 5i   &    � {�$ False��6C   . �5j   *   �� $ border��61    � �� �#CCC6[   �� 5k   *    � ��
 �����6G   5l   '   5n      5p      5q      5r      5s      5t      5u      