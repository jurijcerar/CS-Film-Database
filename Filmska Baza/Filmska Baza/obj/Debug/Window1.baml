   M S B A M L   `   `   `  ����G  CFilmska Baza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Filmska_BazaFilmska_Baza  5   	       Filmska_Baza.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Filmska_Baza     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�62    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $" Resources/UI_Dictionary.xaml?�6%   %    5      ��5      �� 5   
   -   5        
background�� �� Color$ White��5   .    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      �� 	 �� To$ YellowX�6%   	 g� Duration$	 0:0:10D�61   
 g� AutoReverse
 .  g� RepeatBehavior$ Forever��6V    �� 
TargetName$ 
background��6o    �� TargetProperty$ Color�6�   5      5      5      .��5      � .+�5    
   �� .@�5!      �� $��300px��6   $
��40px��6$   $#��Nastavljanje filmskih žanrov��62   .��5"      ��    Main_Stuff_Style#��[  6   .+�5#      ��  �� Orientation$ 
Horizontal=�6!   .+�5$      �� -   5        $��Add_Genre_Textbox��5$   >   $
��30px��6"   $��400px��60   6Y   �� 5%      -   5        $
��30px��5%   !   $
��60px��6/     Button_Style2#��[ 6N   .��6u   Dodaj6|   �� 5&      -   5        $
��30px��5&   !   $
��60px��6/   #��[ 6Q   .��6x   
Odstrani6�   �� 5'      -   5        $
��30px��5'   !   $
��60px��6/   #��[ 6O   .��6v   Uredi6}   5(      �� 5)      -   5        $��Genres_List��5)      64   5*      5+      �� 5,      $��300px��6   $
��40px��6$   $,��&Nastavljanje avtomatskega shranjevanja��62   .��5-      �� #��[  6   .+�5.      �� $
��Bold"�6   $
��30px��6.   .��6<    Čas avtomatskega shranjevanja6[   �� 5/      -   5        $��AS_time��5/      $
��30px��6.   .��6<   06?   �� 50      $��10q�6!   .+�51      �� $
��30px��6    $
��Bold"�6.   .��6@   " Vklopi avtomatskego shranjevanje6b   �� 52      -   5        $��AS_bool��52   #   .��63   Da67   53      �� 54      -	   5         �� 	IsDefault . #��[ 54   D   .��6k   Accept6s   55      56      57      �� 58   
   .+�59      A� -
   5        $	��dot��59      $��10��6#   $��10��6.   
���  ��
 �� Top$	 270��6E    �� Left$	 150��6V    5:      :� 5;      $ Ellipse.Loaded��6#   .[�5<      �� .��5=      �� $ Forever��6)   .��5>   "   T� $	 0:00:05D�6;    T� Source$ X=�6N   $ (Canvas.Left)�6Y     pot T� PathGeometry# [ 6�   T� 5?   "   $	 0:00:05D�6;   $ Y=�6N   $ (Canvas.Top)�6Y   # [ 6�   5@      5A      5B      5D      5E      5F      5G      