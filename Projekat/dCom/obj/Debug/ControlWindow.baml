   M S B A M L   `   `   `  ����?  ;dCom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:dComdCom  5   	   1clr-namespace:dCom.ConvertersdCom.Converters  5         dCom.ControlWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:dCom     5   	   4
convertersclr-namespace:dCom.Converters     5      $	��170��5	      $	��300��6     � ShowInTaskbar  .   � 
ResizeMode$ NoResize=�5
       � WindowStartupLocation$ CenterOwner=�5       � 	Resources 5      4   .dCom.Converters.PointTypeToVisibilityConverter   PointTypeConverter��%   &	          5      6.   5      .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��6(   .+�5      �� $��Current Value��6   $	��290��6%   .��5      �� ��6   �� *DisplayValue+5      5      �� 5      $ 
Horizontal=�6   $��1��6(   $	��290��65   y�6B   �� *Type+ �� 	Converter# [  .+�5      �� $��Commanded Value: ��6   �� 5       .��5!      �� $	��100��6   $	��100��6   $��Stretch=�5"   ?   ��5!   ,   �� *CommandedValue+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 �� ValidatesOnDataErrors	 . 
 �� ValidatesOnExceptions
 . .��5"   ]    =� ErrorTemplate 5#      �� 5$      .R�5%   	   �� $��3q�6   
���  �� � ToolTip 66   �� *[0].ErrorContent+._�5&   
   � .+�5'      �  � Points' �   �J]��  ����  ����� 
���  ��
���  ��6<   �� 5(       ��Name$ textBox��6%   5)      5*   
   5+   	   .��5,   !   5-      5.      5/      �� 51      $��2��6   $��Write��6   $��5q�6I   ��6(   �� *WriteCommand+y�52      �� *Type+# [  �� 53      $��3��6   $
��Read��6   $��5q�6G   ��6'   �� *ReadCommand+6G   54      55      