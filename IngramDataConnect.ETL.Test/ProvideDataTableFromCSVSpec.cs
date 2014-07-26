using System.IO;
using ExpectedObjects;
using NUnit.Framework;
using Should;
using Should.Core.Exceptions;
using SpecsFor;

namespace IngramDataConnect.ETL.Test
{
    public class ProvideDataTableFromCSVSpec
    {
        public class given_reading_the_file_was_unsuccessfull_when_getting_datatable : SpecsFor<ProvideDataTableFromCSV>
        {
            protected override void Given()
            {
                GetMockFor<IReadFile>()
                    .SetupProperty(x => x.IsSuccessfullRead, false);
            }

            protected override void When()
            {
                SUT.GetDataTable("WRONG PATH");
            }

            [Test]
            public void then_it_should_NOT_return_a_DataTable()
            {
                SUT.PopulatedDataTable.ShouldBeNull();
            }

        }
    }
}