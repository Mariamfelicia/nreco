using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NUnit.Framework;
using NReco;
using NReco.Composition;
using NReco.Collections;
using NReco.LinqDynamic;

namespace NReco.Tests {

	[TestFixture]
	public class LinqDynamicTests {

		[Test]
		public void EvalDynamic() {
			var eval = new EvalDynamic();
			eval.ExposeVars = true;
			var c1 = new Dictionary<string, object> { {"a", 7} };
			Assert.AreEqual(12, eval.Eval("a+5", c1) );
			eval.ExposeVars = false;
			Assert.AreEqual(12, eval.Eval(@"Convert.ToInt32(var[""a""])+5", c1));


		}

		[Test]
		public void EvalDynamicPerfTest() {
			var eval = new EvalDynamic();
			var cntx = new Dictionary<string,object>() { {"a", 7}, {"b", "hello"} };
			var cntx2 = new Dictionary<string, object>() { { "a", 8 }, { "b", "hell" } };

			var dt = DateTime.Now;
			for (int i = 0; i < 50000; i++) {
				object res = eval.Eval("Convert.ToInt32(var[\"a\"])>5 && Convert.ToInt32(var[\"a\"])+var[\"b\"].ToString().Length==12", cntx);
				Assert.AreEqual(true, res);
				res = eval.Eval("Convert.ToInt32(var[\"a\"])>5 && Convert.ToInt32(var[\"a\"])+var[\"b\"].ToString().Length==12", cntx2);
				Assert.AreEqual(true, res);
			}
			Console.WriteLine(DateTime.Now.Subtract(dt).TotalSeconds.ToString());
		}



	}
}
