   M S B A M L   `   `   `  ����  QuotesInMSWord'    !QuotesInMSWord.TickerInputControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��10q�5      .��5      �   � 	Resources  5   
      CustomTextBoxStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� RelativeSource �� Path��%v  &	        �� 5	      " ��6/   .�5
      ��  � ��$ 5q�6+   �� 5       � ��$ 20��6+   �� 5       � ��$ Center=�6?   �� 5       � ��$ Center=�6=    5      P� 5       �@=�HasError .  �5      �� 5       �@�ToolTip 68   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5      5      5      .+�5   
   �� 
����  �._�5   
   �� .+�5      �� $��Enter ticker symbols:��6   �� 5      #��[  6u   ��6   �� *InputSymbols+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� ValidatesOnDataErrors
 . 6u   �� 5      $��Generate Table��6   $	��100��6.   $��20��6:    �� 	IsDefault . ��6G   �� *GenerateTableCommand+6p   �� 5      $
��Wrap=�66   $��70��6J   
���  ��$��5,5,0,0q�6g   $
��Auto=�6x   ��6   �� *ErrorMessage+6x   5      5      5      5       