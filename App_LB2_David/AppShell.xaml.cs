using App_LB2_David.Pages;

namespace App_LB2_David;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("Q1_1", typeof(Q1_1));
        Routing.RegisterRoute("Q1_2", typeof(Q1_2));
        Routing.RegisterRoute("Q1_3", typeof(Q1_3));
        Routing.RegisterRoute("Q1_4", typeof(Q1_4));

        Routing.RegisterRoute("Q2_1", typeof(Q2_1));

        Routing.RegisterRoute("InfoPage", typeof(InfoPage));

        Routing.RegisterRoute("AskedQuestionPage", typeof(AskedQuestionPage));
    }
}
