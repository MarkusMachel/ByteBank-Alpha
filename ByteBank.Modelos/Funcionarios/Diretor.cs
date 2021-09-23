namespace ByteBank.Modelos.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        public Diretor(double salario, string cpf) : base(salario, cpf)
        {

        }
        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
        internal protected override double GetBonificacao()
        {
            return Salario * 0.5;
        }
    }
}