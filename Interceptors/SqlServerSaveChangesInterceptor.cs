using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoIGL.Interceptors
{
    public class SqlServerSaveChangesInterceptor : DbCommandInterceptor
    {
        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            // Verifica se o comando SQL contém OUTPUT e remove essa cláusula
            if (command.CommandText.Contains("OUTPUT"))
            {
                command.CommandText = command.CommandText.Replace("OUTPUT", "-- OUTPUT");
            }

            // Retorna o método base com ValueTask, conforme a assinatura correta do método
            return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
        }
    }
}
