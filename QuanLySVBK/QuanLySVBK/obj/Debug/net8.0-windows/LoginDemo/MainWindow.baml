   M S B A M L   `   `   `  ����  	LoginDemo    LoginDemo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Màn hình chính��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$ SingleBorderWindow=�5   	    � WindowState$ 	Maximized=�5   	   .��5	      ]� .+�5   
   �� ���#e62c2c$	��Top=�6*    �� Orientation$ 
Horizontal=�6?   $	��118��6X   .+�5      �� $"��Images/logo_dai_hoc_bkhn.png��6   $��99��5      $��	15,5,10,5q�6    $��Center=�63   �� 5      $��Center=�6   $
��20,0q�64   .+�5      �� $'��!ĐẠI HỌC BÁCH KHOA HÀ NỘI��6   $��26(�6<   
�������$
��Bold"�6]   �� 5      $(��"HỆ THỐNG QUẢN LÝ SINH VIÊN��6   $��19(�6>   
�������6L   5      �� 5      -   5         ��Name$ LoginButton��5      $��ĐĂNG NHẬP��5   	   $	��200��5      $��40��6!   $
��Bold"�5      ���#9CABF5
�������$��0q�5      $��
500,0,20,0q�5       $��Center=�5!      $��Right=�5"       � Cursor$
 Hand��5#      $��19(�5$      ��5%      �� 5&       �� 
TargetType" ��6&   .R�5'      ��  ��Name$ border��6!   #��z��5(   !   	 �� CornerRadius$	 20��5)   !   #��z��5*   !   #��z��5+   !   ._�5,      �� $��Center=�6/   $��Center=�6L   5-      
 �� Triggers
 5.      P� 5/       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �50   "   ��  �� 
TargetName$ border��6)    �� Property � �� �� Value �#7A93F76S   51      P� 52       � ��$
 True��6;   . �53   "   �� $ border��6)    � �� �#5A75E66S   54      P� 55       � {�$ False��6;   . �56   "   �� $ border��6)    � �� �#CCC6S   �� 57   "    � ��
 �����6?   58      5:      5<      5=      o� 5@   
   $	��Top=�6   
���   �$��34��67    � 	Resources 5A         MainMenuHeaderTextBlock �� 
TargetType  SubMenuItemStyle �� Triggers��%V  &	        &	 �     �� 5B      " ��68   .�5C      ��  � ��
 �����63   �� 5D       � ��$ 17(�61   �� 5E       � ��$ SemiBold"�63   �� 5F       �@��Padding$	 0,4q�60   5G      �� 5I      " m�61   .�5J      ��  � ��
 ���� 63   �� 5K       � ��
 ��  �63   �� 5L       � ��$
 10,4q�60   �� 5M       � ��$ 16(�61   �� 5N       � ��$ Normal"�63    5O      P� 5P       �@J�IsMouseOver$
 True��69   . �5Q      ��  � �� �#D0E7FF6;   �� 5R       � ��
 ��  �6;   5S      5U      5V      .@�5Y      m� $��	20,0,20,0q�6   ��5Z      �� 5[      $��TRANG CHỦ��6    #��[  61   5]      m� 5_      $��0,0,20,0q�6   ��5`      �� 5a      $��HỆ THỐNG��6    #��[  60   .@�5c      m� $��Thông tin tài khoản��6   #��[ 68   m� 5d      $��Đổi mật khẩu��6   #��[ 61   5e      m� 5g      $��0,0,20,0q�6   ��5h      �� 5i      $��XỬ LÝ ĐIỂM��6    #��[  62   .@�5k      m� -   5        $��Xử lý CPA��5k      #��[ 6.   6X   m� 5l      -   5        $��Xử lý GPA��5l      #��[ 6.   6X   m� 5m      -   5        $.��(Xử lý điểm tổng kết môn học��5m      #��[ 6@   6j   5n      m� 5p      -   5        $��0,0,20,0q�5p      ��5q      �� 5r      $��CẬP NHẬT ĐIỂM��6    #��[  65   5u      m� 5w      $��0,0,20,0q�6   ��5x      �� 5y      $��THỐNG KÊ��6    #��[  60   .@�5{      m� $)��#Thống kê kết quả học tập��6   #��[ 6=   5|      m� 5~      $��0,0,20,0q�6   ��5      �� 5�      $��
DANH MỤC��6    #��[  60   .@�5�      m� $��Ngành học��6   #��[ 6.   m� 5�      $!��Chương trình đào tạo��6   #��[ 69   5�      5�      � 5�      -   5         �Name$ MainContentArea��5�      .+�5�      �� $4��.Images/dither_it_background_man_hinh_chinh.jpg��6   $
��Fill=�5�      �� 5�      -   5         ��Name$ MainContentControl��5�   !   5�      5�      5�      