module Fitts

open System;;
open System.Windows.Forms;;
open System.Drawing;;

type Record =
    struct
        val time  : TimeSpan
        val width : int
        new(t:TimeSpan , w:int) = {time = t ; width = w}
    end


let SubTime (time : DateTime) = DateTime.Now.Subtract(time)

type Fitts () as self =
  class
    inherit Form ()
    let mutable recordList : Record list = []
    let mutable beginTime : DateTime = DateTime.Now
    let mutable width : int = 100
    let mutable bLeft = new Button(
                            Location = new Point ((600-width)/2,0),
                            Name = "bLeft",
                            Size = new Size (width,800),
                            TabIndex = 1,
                            UseVisualStyleBackColor = true)
    let mutable bRight = new Button(
                            Location = new Point ((1800-width)/2,0),
                            Name = "bLeft",
                            Size = new Size (width,800),
                            TabIndex = 1,
                            UseVisualStyleBackColor = true)
    let mutable counter = 10
    let mainmenu = self.Menu <- new MainMenu() in
    let mFile = self.Menu.MenuItems.Add("ファイル(%F)") in
    let mmStart = mFile.MenuItems.Add("再開(&S)") in
    let mmEnd = mFile.MenuItems.Add("終了(&x)") in
    do
        self.ClientSize <- new Size (1200,600)
        self.Controls.Add bLeft
        self.Controls.Add bRight
        self.Name = "FItts"
        self.Text = "フィッツの法則追実験"
        self.ResumeLayout false

    do bLeft.Click.Add (fun e ->  recordList <- Record(SubTime(beginTime),width)::recordList);
    do bRight.Click.Add (fun e -> recordList <- Record(SubTime(beginTime),width)::recordList );
    do mmStart.Click.Add (fun _ -> printf "再開！");
    do mmEnd.Click.Add (fun _ -> self.Close());
  end;;

do
Application.Run(new Fitts ())
