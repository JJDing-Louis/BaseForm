# [C# ]WinForm的表單的啟動順序與應用
## 1.前言

維護前輩們的程式碼時，為了讓使用者操作友善，不需要多個步驟開啟程式的方式，於是查了資料嘗試編寫，發現很多地方需要留意，主要根據**Form.Load**、**Form.Shown**、**Form.Closing**與**Form.Closed**這幾個方式去做，才能達到預期得效果。
	
## 2. 作法

一般來說，程式執行時，會經過以下步驟

Step 1. 程式從**Program.cs**開始執行，並呼叫裡面的 **Main()**
```cs
static void Main()  
{  
 Application.EnableVisualStyles();  
 Application.SetCompatibleTextRenderingDefault(false);  
 Application.Run(new BaseForm());  //開始執行BaseForm()
}
```

Step 2. 程式執行**BaseForm()**這段程式碼
```cs
public BaseForm()  
{  
 InitializeComponent();  
}

```

Step 3. 然後會在**BaseForm.Designer.cs**執行**InitializeComponent()**
```cs
 /// <summary>
 /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
 /// 這個方法的內容。
 /// </summary>
 private void InitializeComponent()
 {
      this.components = new System.ComponentModel.Container();
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Text = "BaseForm"; //(待修改)
 }
```

簡單來說就是:
> **Main() **=> **表單的Class名稱 **=> **InitializeComponent()**

通常InitializeComponent()為程式執行時，進行UI繪圖與基本視窗功能建立，通常不建議使用者在此段程式碼加上額外的Code 引起不必要的問題，但是如果要在表單載入或者結束時，建立相對應的工作，可以參照以下表格的事件進行編寫。

| 事件              | 說明                                          |
| ----------------- | --------------------------------------------- |
| **Form.Load**事件    | 發生在表單第一次顯示之前。                    |
| **Form.Shown**事件   | 只有當第一次顯示表單時，才會引發 Shown 事件。 |
| **Form.Closing**事件 | 發生於表單正在關閉時。                        |
| **Form.Closed**事件 |  發生於表單已關閉時。                     |

以下範例舉例:

Example 1. 要在表單進行載入時觸發事件 =>  **Form.Load 事件**
```cs
 /// <summary>
 /// 表單進行載入時觸發事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 private void BaseForm_Load(object sender, EventArgs e)
 {
     MessageBox.Show("BaseForm開始載入!");
 }
```

執行結果:
![](https://i.imgur.com/m1BawsP.png)



Example 2. 要在表單進行載入時觸發事件 =>  **Form.Shown 事件**
```cs
 /// <summary>
 /// 表單載入後進行觸發事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 private void BaseForm_Shown(object sender, EventArgs e)
 {
     MessageBox.Show("BaseForm開始完畢!");
 }
```

執行結果:
![](https://i.imgur.com/kLLNgYG.png)


Example 3. 要在表單進行載入時觸發事件 =>  **Form.Closing 事件**
```cs
 /// <summary>
 /// 表單開始關閉時，進行觸發事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
 {
     MessageBox.Show("BaseForm開始關閉!");
 }
```

執行結果:
![](https://i.imgur.com/pBaKZQR.png)


Example 4. 要在表單進行載入時觸發事件 =>   **Form.Closed 事件**
```cs
 /// <summary>
 /// 表單關閉後，開始進行觸發事件
 /// </summary>
 /// <param name="sender"></param>
 /// <param name="e"></param>
 private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
 {
     MessageBox.Show("BaseForm已經關閉!");
 }
```

執行結果:
![](https://i.imgur.com/6sRT6sj.png)


## 3. 完整程式碼

**Base.Form.cs**
```cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseForm
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表單關閉後，開始進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("BaseForm已經關閉!");
        }

        /// <summary>
        /// 表單開始關閉時，進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("BaseForm開始關閉!");
        }

        /// <summary>
        /// 表單進行載入時觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("BaseForm開始載入!");
        }

        /// <summary>
        /// 表單載入後進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("BaseForm開始完畢!");
        }
    }
}
```

**BaseForm.Designer.cs**
```cs

namespace BaseForm
{
    partial class BaseForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Shown += new System.EventHandler(this.BaseForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}


```

## 4. 常見問題
1. **InitializeComponent()** 這部分主要是給程式啟動初始化作業時，建立繪圖層與控鍵的委派事件的建立，建議此部分可以把參數傳遞出來，但是不建議在這區塊建立==方法==或者==事件==。


## 5. 參考資料
1. [看範例學C#-07 Windows Form 表單的啟動順序](https://dotblogs.com.tw/hung-chin/2011/10/01/38490)
