   M S B A M L   `   `   `  ����C  ?WpfPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfPaintWpfPaint  5   	   S OWpfEditingControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:WpfEditingControlLibrary;assembly=WpfEditingControlLibraryWpfEditingControlLibrary 5   	   M IWpfControlLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1WpfControlLibrary1 6s       WpfPaint.AnimationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfPaint     5   	   mWpfEditingControlLibraryHclr-namespace:WpfEditingControlLibrary;assembly=WpfEditingControlLibrary     5   	   [WpfControlLibrary1<clr-namespace:WpfControlLibrary1;assembly=WpfControlLibrary1     6s     � Title$  AnimationWindow��5	   	   $��612.256��6!   $��964.693��62    � 	Resources 5
         ButtonStyle1 �� 
TargetType �� Property �� Value �� 
TargetType �� RadiusY �� RadiusX J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value  ButtonStyle3  ButtonStyle2  ButtonStyle4��%�  &	        &	 �    &	 �    &	 �    �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� ���	#FFF4F4F5$ 3��69   $ 3��6E   
���   �6Q   �� 5      #��z��6/   ��. # z 6�   #��z��6�   5      	 5      P� 5      
 �@J�	IsFocused . 6;   P� 5      
 �@��IsDefaulted . 6=   P� 5      
 �@J�IsMouseOver . 6=   P� 5      
 � �� . 6;   P� 5      
 � {� .  6;   5      5      5      �� 5   
   " ��6%   .�5      ��  � �� 5       �� 5!      " ��6&   .R�5"      � .+�5#      �� ���	#FFF4F4F5$ 3��69   $ 3��6E   
���   �6Q   �� 5$      #��z��6/   ��. # z 6�   #��z��6�   5%      	 5&      P� 5'      
 �@J�	IsFocused . 6;   P� 5(      
 �@��IsDefaulted . 6=   P� 5)      
 �@J�IsMouseOver . 6=   P� 5*      
 � �� . 6;   P� 5+      
 � {� .  6;   5-      5/      50      �� 51   
   " ��6%   .�52      ��  � �� 53      �� 54      " ��6&   .R�55      � .+�56      �� ���	#FFF4F4F5$ 3��69   $ 3��6E   
���   �6Q   �� 57      #��z��6/   ��. # z 6�   #��z��6�   58      	 59      P� 5:      
 �@J�	IsFocused . 6;   P� 5;      
 �@��IsDefaulted . 6=   P� 5<      
 �@J�IsMouseOver . 6=   P� 5=      
 � �� . 6;   P� 5>      
 � {� .  6;   5@      5B      5C      �� 5D   
   " ��6%   .�5E      ��  � �� 5F      �� 5G      " ��6&   .R�5H      � .+�5I      �� ���	#FFF4F4F5$ 3��69   $ 3��6E   
���   �6Q   �� 5J      #��z��6/   ��. # z 6�   #��z��6�   5K      	 5L      P� 5M      
 �@J�	IsFocused . 6;   P� 5N      
 �@��IsDefaulted . 6=   P� 5O      
 �@J�IsMouseOver . 6=   P� 5P      
 � �� . 6;   P� 5Q      
 � {� .  6;   5S      5U      5V      5\      .��5]      � $��
0,0,-8,-21q�6   .+�5_   
   6  0System.Windows.Controls.Ribbon.RibbonTwoLineText  $
��Left=�6   $��
617,85,0,0q�67   $	��Top=�6K   $	��100��6c   +  %System.Windows.Controls.Ribbon.Ribbon  5`   
   -   5        $
��Left=�5`      $	��157��6,   $��0,1,0,0q�69   $	��Top=�6J   $	��957��6b   .@�5a      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6   $
��Left=�6&   $	��105��6A   $	��Top=�6N   $	��957��6f   $��
0,0,-2,-17q�6r   .@�5b      0  *System.Windows.Controls.Ribbon.RibbonGroup  $
��File��6   $	��105��6,   $��0q�69   $	��Top=�6D   $	��144��6\   .@�5c      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5          Name$ Save_btn��5c   #   $
��Left=�65   $��10,0,-53,-39q�6P   $��47��6f   
���   ����	#FFCED9DA6�   �� 5d      $��Save as��6   $��10,10,12,-33q�6.     5e      -   5        $ 
ButtonLoad��5e   #   $��RibbonButton��67   $
��Left=�6N   $��38��6i   $��71,43,-114,-73q�6u   $	��Top=�6�   $��47��6�   
���   ����	#FFCED9DA6�     5f      -   5        $ Export_button��5f   #   $
��Left=�6:   $��40��6U   $��71,-9,-114,-23q�6a   $	��Top=�6y   $��47��6�   
���   ����	#FFCED9DA6�     5g      -   5        $ Btn_copy��5g   #   $
��Copy��65   $��
-60,48,0,0q�6D   $	��Top=�6X   $��36��6p   $
��Left=�6|   $��44��6�   
���   ����	#FFCED9DA6�   �� 5h      $��Export��6   $��4,-78,71,53q�6-   �� 5i      $
��Load��6   $
��Left=�6+   $��7,-33,-43,0q�6F   $	��Top=�6[   �� 5j      $
��Copy��6   $
��Left=�6+   $��-56,-31,0,0q�6F   $	��Top=�6[   5k        5l      $��Editing��6   $	��105��6/   $��0q�6<   $	��Top=�6G   $	��188��6_   .@�5m      �� -   5         ��Name$ BrushComboBox��5m      $
��Left=�66   $��90,10,-80,52q�6Q   $��88��6g    �� 
IsEditable .  J� RenderTransformOrigin$ 0.5,0.5&�6�   .@�5n      �� -   5         ��Name$ Item_Pencil��5n   '    �� 
IsSelected . $��Pencil��6n   �� 5o      -   5        $ Item_Thinbrush��5o   '   $��
Thin Brush��6b   �� 5p      -	   5        $ Item_Midbrush��5p   '   $��Medium Brush��6`   �� 5q      -
   5        $ Item_Thickbrush��5q   '   $��Thick Brush��6d   5r      �� 5s      -   5         ��Name$ BtnZoom1��5s      $�� ��6/   $
��Left=�6:   $��-101,67,0,-44q�6U   $	��Top=�6l   $��19��6�   $��17��6�   ��5t      �� 5u       �� ImageSource$j dG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\zoom_1.png��6)   5w      �� 5x      -   5        $ BtnZoom2��5x      $�� ��6/   $
��Left=�6:   $��
-79,67,0,1q�6U   $��19��6i   ��5y      �� 5z      $j dG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\zoom_2.png��6)   5|      �� 5}      -   5        $ BtnText_block��5}      $�� ��64   $
��Left=�6?   $��-55,68,0,-44q�6Z   $	��Top=�6p   $��21��6�   $��16��6�   ��5~      �� 5      $n hG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\ui_textbox.PNG��6)   5�      �� 5�      -   5        $ BtnDraw_text��5�      $�� ��63   $
��Left=�6>   $��-24,0,0,-44q�6Y   $��18��6n   $��17��6�   $��Bottom=�6�   ��5�      �� 5�      $m gG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\draw_text.jpg��6)   5�      �� 5�      -   5        $��Right=�5�      $��
-9,0,-51,0q�6;   $��88��6O    . .@�5�      �� -   5        $ Item_BlackLine��5�   '    . $��
Black Line��6t   �� 5�      -   5        $ Item_RedLine��5�   '   $��Red Line��6^   �� 5�      -   5        $ Item_BlueLine��5�   '   $��	Blue Line��6`   5�      �� 5�      -   5         ��Name$ SwitchHighliter��5�      $��Highlighter��68   $
��Left=�6N   $��
-125,9,0,0q�6i   $	��Top=�6}   6�   �� 5�      -   5        $ BtnDraw_triangle��5�      $�� ��67   $��-28,44,0,-31q�6B   ��5�      �� 5�      $l fG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\triangle.PNG��6)   5�      �� 5�      -   5        $ Btn_Background_colour��5�      $��	Dark Mode��6>   $
��Left=�6R   $��-125,29,0,-14q�6m   $	��Top=�6�   6�   �� 5�      -   5        $ SwitchBrushMode��5�      $��White brush��68   $
��Left=�6N   $��-125,17,0,-2q�6i   $	��Top=�6   6�   �� 5�      -   5        $ Btn_BezierCurve��5�      $�� ��66   $��10,10,-40,-30q�6A   ��5�      �� 5�      $o iG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\BezierCurve.PNG��6)   5�      5�        5�      $��Colours��6   $	��105��6/   $��0q�6<   $	��Top=�6G   $	��186��6_   .@�5�      %  WpfControlLibrary1.UserControl1  -   5          Name$ ColourPicker��5�   6   $
��Left=�6L   $	��111��6g   $��-14,-6,0,-37q�6t   $	��Top=�6�   $	��200��6�   6�   5�        5�      $��Shapes and Drawing��6   $	��105��6:   $��0q�6G   $	��Top=�6R   $	��211��6j   .@�5�      �� -   5        $ Btn_ellipse��5�      $��Ellipse��62   $
��Left=�6D   $��0,62,-35,-42q�6_   $	��Top=�6u   $��75��6�   6�   �� 5�      -   5        $ Btn_strokesSquare��5�      $��Square��68   $
��Left=�6I   $��97,23,-132,-3q�6d   $��75��6{   $��20��6�   $	��Top=�6�   6�   �� 5�      -   5        $ Btn_polyline��5�      $��Polyline��63   $
��Left=�6F   $��76,10,-111,10q�6a   $��75��6x   6�   �� 5�      -   5        $ Button_polygonSquare��5�      $��PolySqre��6;   $��80,0,-150,0q�6N   6c   �� 5�      -   5        $ BtnDraw_Arc��5�      $�� ��62   $��-35,-51,-16,12q�6=   ��5�      �� 5�      $j dG:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Icons\arcicn.PNG��6)   5�        5�      -   5        $ 	Btn_Paste��5�   #   $��Paste��66   $��-17,10,-25,-7q�6F   $	��Top=�6]   $��37��6u   
���   ����	#FFCED9DA6�   �� 5�      $��Paste��6   $
��Left=�6,   $��-14,-28,-24,0q�6G   $	��Top=�6^   5�        5�      $��
Animations��6   $	��105��62   $��0q�6?   $	��Top=�6J   $	��228��6b   .@�5�      �� -   5        $ BtnFade_animate��5�      $��Fade Animation��66   $
��Left=�6O   $��10,10,-50,0q�6j   $	��Top=�6   $��80��6�   6�   �� 5�      -    5        $ Btn_rotate_animation��5�      $��Rotate��6;   $
��Left=�6L   $��10,10,-66,0q�6g   $	��Top=�6|   $��75��6�   6�   �� 5�      -!   5        $ Btn_pathAnimation��5�      $��Animate path��68   $
��Left=�6O   $��10,10,-54,-30q�6j   $	��Top=�6�   $��84��6�   6�   �� 5�      -"   5        $ AnimationFade_Combobox��5�      $
��Left=�6?   $��109,-24,-177,0q�6Z   $	��Top=�6r   $��96��6�    . .@�5�      �� -#   5        $ Item_Square_fade��5�   (    . $��Fade Square��6y   �� 5�      -$   5        $ Item_Ellipse_fade��5�   (   $��Fade Ellipse��6i   �� 5�      -%   5        $ Item_Triangle_fade��5�   (   $��Fade Triangle��6k   5�      �� 5�      -&   5        $ AnimationColour_Combobox��5�      $
��Left=�6A   $��111,-53,-182,0q�6\   $	��Top=�6t   $��99��6�    . .@�5�      �� -'   5        $ Item_Square_color��5�   (    . $��Colour Square��6{   �� 5�      -(   5        $ Item_Ellipse_color��5�   (   $��Colour Ellipse��6k   �� 5�      -)   5        $ Item_Triangle_color��5�   (   $��Colour Triangle��6m   5�      �� 5�      -*   5        $ Btn_animatePolyline��5�      $��Line animation��6:   $
��Left=�6S   $��71,64,-124,-44q�6n   $	��Top=�6�   $��93��6�   6�   5�      5�      5�      �� 5�   
   -+   5         ��Name$ animationInkCanvas��5�      $
��Left=�60   $	��297��6K   $��
26,181,0,0q�6X   $	��Top=�6l   $	��905��6�    �� 
Background �	#FFCED9DA6�   �� 5�   
   -,   5        $��image1��5�      $��10,35,-10,-35q�6   �� 5�   
   $
��Left=�6   $��36��6/   $��	0,541,0,0q�6;   $	��Top=�6N   $	��957��6f   .@�5�      �� --   5        $ 
Btn_Delete��5�      $��Clear��6)   $��43��69   $��20��6D   6P   �� 5�      -.   5        $ Btn_undo��5�      $
��Undo��6'   $��48��66   6A   �� 5�      -/   5        $ 
Btn_Select��5�      $��Select��6)   $��48��6:   6E   �� 5�      -0   5        $ 
Btn_eraser��5�      $��Eraser��6)   $��54��6:   6E   �� 5�      -1   5        $ Strokes_Delete��5�      $��Del Strokes��6-   $��65��6C   6N   �� 5�      -2   5        $ endAnimation��5�      $��Finish��6+   $��51��6<   6G   �� 5�      -3   5        $ Btn_ImgScale��5�      $��Scale Image��6+   $��51��6A   6L   5�      �� 5�   
   $��59��6   $��	0,482,0,0q�6!   $	��Top=�64   #��� ��6L   .+�5�      �� -4   5         ��Name$ TimeListBox��5�      $��57��6+   $��	0,0,453,0q�5�      
������ ��5�      �� *	TimeLines+�� 5�      
���   �$��1q�6)   $��35��6=   5�      5�        5�   
   $
��Left=�6   $��54,-231,0,0q�67   $	��Top=�6L   $	��100��6d   5�      5�      