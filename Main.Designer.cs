namespace Distribution
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.enterBtn = new System.Windows.Forms.Button();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.Item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.info = new System.Windows.Forms.Label();
            this.sum = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTrackingNumber.Location = new System.Drawing.Point(55, 26);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(487, 35);
            this.txtTrackingNumber.TabIndex = 0;
            // 
            // enterBtn
            // 
            this.enterBtn.Location = new System.Drawing.Point(586, 26);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(127, 35);
            this.enterBtn.TabIndex = 1;
            this.enterBtn.Text = "조회";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewItems
            // 
            this.listViewItems.CheckBoxes = true;
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item_name,
            this.item_code,
            this.order_id});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(55, 113);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(487, 300);
            this.listViewItems.TabIndex = 2;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            // 
            // Item_name
            // 
            this.Item_name.Text = "상품이름";
            this.Item_name.Width = 137;
            // 
            // item_code
            // 
            this.item_code.Text = "상품코드";
            this.item_code.Width = 131;
            // 
            // order_id
            // 
            this.order_id.Text = "주문번호";
            this.order_id.Width = 121;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("돋움체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.info.Location = new System.Drawing.Point(53, 80);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 24);
            this.info.TabIndex = 3;
            // 
            // sum
            // 
            this.sum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sum.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sum.Location = new System.Drawing.Point(586, 113);
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            this.sum.Size = new System.Drawing.Size(127, 32);
            this.sum.TabIndex = 4;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "초기화";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.info);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.txtTrackingNumber);
            this.Name = "Form1";
            this.Text = "배송관리";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTrackingNumber;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader Item_name;
        private System.Windows.Forms.ColumnHeader item_code;
        private System.Windows.Forms.ColumnHeader order_id;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.TextBox sum;
        private System.Windows.Forms.Button button2;
    }
}

