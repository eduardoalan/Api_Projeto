using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Projeto.Models
{
    public partial class projeto_lilian_modasContext : DbContext
    {
        public projeto_lilian_modasContext()
        {
        }

        public projeto_lilian_modasContext(DbContextOptions<projeto_lilian_modasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cor> Cor { get; set; }
        public virtual DbSet<Crediario> Crediario { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<ItemPedido> ItemPedido { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Notafiscal> Notafiscal { get; set; }
        public virtual DbSet<Parcelas> Parcelas { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        public virtual DbSet<ProdutoTamanho> ProdutoTamanho { get; set; }
        public virtual DbSet<ProfissionalPessoal> ProfissionalPessoal { get; set; }
        public virtual DbSet<Referencias> Referencias { get; set; }
        public virtual DbSet<Tamanho> Tamanho { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=projeto_lilian_modas;Port=5433;User Id=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("cliente_pk");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.DsCpfCnpj)
                    .IsRequired()
                    .HasColumnName("ds_cpf_cnpj")
                    .HasMaxLength(50);

                entity.Property(e => e.DsNaturalidade)
                    .HasColumnName("ds_naturalidade")
                    .HasMaxLength(100);

                entity.Property(e => e.DsRgUf)
                    .IsRequired()
                    .HasColumnName("ds_rg_uf")
                    .HasMaxLength(10);

                entity.Property(e => e.DsTipo)
                    .IsRequired()
                    .HasColumnName("ds_tipo")
                    .HasMaxLength(50);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.DtNascimento)
                    .HasColumnName("dt_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.IdCrediario).HasColumnName("id_crediario");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.IdProfissionalPessoal).HasColumnName("id_profissional_pessoal");

                entity.Property(e => e.IeSexo)
                    .HasColumnName("ie_sexo")
                    .HasMaxLength(20);

                entity.Property(e => e.Nmcliente)
                    .IsRequired()
                    .HasColumnName("nmcliente")
                    .HasMaxLength(100);

                entity.Property(e => e.StFornecedor).HasColumnName("st_fornecedor");

                entity.HasOne(d => d.IdCrediarioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdCrediario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("crediario_cliente_fk");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("endereco__cliente_fk");

                entity.HasOne(d => d.IdProfissionalPessoalNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdProfissionalPessoal)
                    .HasConstraintName("profissional_pessoal__cliente_fk");
            });

            modelBuilder.Entity<Cor>(entity =>
            {
                entity.HasKey(e => e.IdCor)
                    .HasName("cor_pk");

                entity.ToTable("cor");

                entity.Property(e => e.IdCor).HasColumnName("id_cor");

                entity.Property(e => e.DsCor)
                    .IsRequired()
                    .HasColumnName("ds_cor")
                    .HasMaxLength(100);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Crediario>(entity =>
            {
                entity.HasKey(e => e.IdCrediario)
                    .HasName("crediario_pk");

                entity.ToTable("crediario");

                entity.Property(e => e.IdCrediario)
                    .HasColumnName("id_crediario")
                    .HasDefaultValueSql("nextval('crediario_id_crediario_seq_1'::regclass)");

                entity.Property(e => e.NmAvalista)
                    .HasColumnName("nm_avalista")
                    .HasMaxLength(100);

                entity.Property(e => e.StAutorizaCartas).HasColumnName("st_autoriza_cartas");

                entity.Property(e => e.StAutorizaEmail).HasColumnName("st_autoriza_email");

                entity.Property(e => e.StAutorizaLigacoes).HasColumnName("st_autoriza_ligacoes");

                entity.Property(e => e.StAutorizaSms).HasColumnName("st_autoriza_sms");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("departamento_pk");

                entity.ToTable("departamento");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.DsDepartamento)
                    .IsRequired()
                    .HasColumnName("ds_departamento")
                    .HasMaxLength(100);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("endereco_pk");

                entity.ToTable("endereco");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.DsCep).HasColumnName("ds_cep");

                entity.Property(e => e.DsComplemento)
                    .HasColumnName("ds_complemento")
                    .HasMaxLength(500);

                entity.Property(e => e.DsLogradouro)
                    .HasColumnName("ds_logradouro")
                    .HasMaxLength(500);

                entity.Property(e => e.DsObservacoes)
                    .HasColumnName("ds_observacoes")
                    .HasMaxLength(1000);

                entity.Property(e => e.DsProximidade)
                    .HasColumnName("ds_proximidade")
                    .HasMaxLength(500);

                entity.Property(e => e.NmBairro)
                    .HasColumnName("nm_bairro")
                    .HasMaxLength(100);

                entity.Property(e => e.NmCidadeUf)
                    .HasColumnName("nm_cidade_uf")
                    .HasMaxLength(100);

                entity.Property(e => e.NmEstado)
                    .HasColumnName("nm_estado")
                    .HasMaxLength(200);

                entity.Property(e => e.NmPais)
                    .HasColumnName("nm_pais")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque)
                    .HasName("estoque_pk");

                entity.ToTable("estoque");

                entity.Property(e => e.IdEstoque).HasColumnName("id_estoque");

                entity.Property(e => e.DsTipo)
                    .IsRequired()
                    .HasColumnName("ds_tipo")
                    .HasMaxLength(20);

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("dt_criacao")
                    .HasColumnType("date");

                entity.Property(e => e.IdNotafiscal).HasColumnName("id_notafiscal");

                entity.Property(e => e.IdProdutoTamanho).HasColumnName("id_produto_tamanho");

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("nm_usuario")
                    .HasMaxLength(100);

                entity.Property(e => e.VlQuantidade).HasColumnName("vl_quantidade");

                entity.HasOne(d => d.IdNotafiscalNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.IdNotafiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notafiscal_estoque_fk");

                entity.HasOne(d => d.IdProdutoTamanhoNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.IdProdutoTamanho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_tamanho_estoque_fk");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("funcionario_pk");

                entity.ToTable("funcionario");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.DsCargo)
                    .IsRequired()
                    .HasColumnName("ds_cargo")
                    .HasMaxLength(50);

                entity.Property(e => e.DsCpf)
                    .IsRequired()
                    .HasColumnName("ds_cpf")
                    .HasMaxLength(50);

                entity.Property(e => e.DsCtps)
                    .IsRequired()
                    .HasColumnName("ds_ctps")
                    .HasMaxLength(50);

                entity.Property(e => e.DsRgUf)
                    .IsRequired()
                    .HasColumnName("ds_rg_uf")
                    .HasMaxLength(50);

                entity.Property(e => e.DsTelefone)
                    .IsRequired()
                    .HasColumnName("ds_telefone")
                    .HasMaxLength(100);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.DtNascimento)
                    .HasColumnName("dt_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IeSexo)
                    .HasColumnName("ie_sexo")
                    .HasMaxLength(20);

                entity.Property(e => e.NmFuncionario)
                    .IsRequired()
                    .HasColumnName("nm_funcionario")
                    .HasMaxLength(100);

                entity.Property(e => e.VlSalario)
                    .HasColumnName("vl_salario")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("endereco__funcionario_fk");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_funcionario_fk");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.IdGrade)
                    .HasName("grade_pk");

                entity.ToTable("grade");

                entity.Property(e => e.IdGrade).HasColumnName("id_grade");

                entity.Property(e => e.DsGrade)
                    .IsRequired()
                    .HasColumnName("ds_grade")
                    .HasMaxLength(100);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.HasKey(e => e.IdItemPedido)
                    .HasName("item_pedido_pk");

                entity.ToTable("item_pedido");

                entity.Property(e => e.IdItemPedido).HasColumnName("id_item_pedido");

                entity.Property(e => e.IdNotafiscal).HasColumnName("id_notafiscal");

                entity.Property(e => e.IdProdutoTamanho).HasColumnName("id_produto_tamanho");

                entity.Property(e => e.VlQuantidade).HasColumnName("vl_quantidade");

                entity.Property(e => e.VlTotal)
                    .HasColumnName("vl_total")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlUnitario)
                    .HasColumnName("vl_unitario")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.IdNotafiscalNavigation)
                    .WithMany(p => p.ItemPedido)
                    .HasForeignKey(d => d.IdNotafiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notafiscal_item_pedido_fk");

                entity.HasOne(d => d.IdProdutoTamanhoNavigation)
                    .WithMany(p => p.ItemPedido)
                    .HasForeignKey(d => d.IdProdutoTamanho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_tamanho_item_pedido_fk");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("marca_pk");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.DsMarca)
                    .IsRequired()
                    .HasColumnName("ds_marca")
                    .HasMaxLength(100);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Notafiscal>(entity =>
            {
                entity.HasKey(e => e.IdNotafiscal)
                    .HasName("notafiscal_pk");

                entity.ToTable("notafiscal");

                entity.Property(e => e.IdNotafiscal)
                    .HasColumnName("id_notafiscal")
                    .HasDefaultValueSql("nextval('notafiscal_id_pedido_seq'::regclass)");

                entity.Property(e => e.DsObservacoes)
                    .HasColumnName("ds_observacoes")
                    .HasMaxLength(500);

                entity.Property(e => e.DsStatus)
                    .IsRequired()
                    .HasColumnName("ds_status")
                    .HasMaxLength(50);

                entity.Property(e => e.DsTipo)
                    .IsRequired()
                    .HasColumnName("ds_tipo")
                    .HasMaxLength(20);

                entity.Property(e => e.DtAlteracao)
                    .HasColumnName("dt_alteracao")
                    .HasColumnType("date");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("dt_criacao")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.VlTotal)
                    .HasColumnName("vl_total")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Notafiscal)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_notafiscal_fk");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Notafiscal)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("funcionario_venda_fk");

            });

            modelBuilder.Entity<Parcelas>(entity =>
            {
                entity.HasKey(e => new { e.IdParcelas, e.IdNotafiscal })
                    .HasName("parcelas_pk");

                entity.ToTable("parcelas");

                entity.Property(e => e.IdParcelas)
                    .HasColumnName("id_parcelas")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdNotafiscal).HasColumnName("id_notafiscal");

                entity.Property(e => e.DtVencimento)
                    .HasColumnName("dt_vencimento")
                    .HasColumnType("date");

                entity.Property(e => e.VlParcela)
                    .HasColumnName("vl_parcela")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.IdNotafiscalNavigation)
                    .WithMany(p => p.Parcelas)
                    .HasForeignKey(d => d.IdNotafiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("venda_parcelas_fk");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("produto_pk");

                entity.ToTable("produto");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.DsGrupo)
                    .IsRequired()
                    .HasColumnName("ds_grupo")
                    .HasMaxLength(200);

                entity.Property(e => e.DsProduto)
                    .IsRequired()
                    .HasColumnName("ds_produto")
                    .HasMaxLength(100);

            
                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");

                entity.Property(e => e.IdCor).HasColumnName("id_cor");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdGrade).HasColumnName("id_grade");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.NmColecao)
                    .IsRequired()
                    .HasColumnName("nm_colecao")
                    .HasMaxLength(100);

                entity.Property(e => e.VlCustoAquisicao)
                    .HasColumnName("vl_custo_aquisicao")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlCustoBase)
                    .HasColumnName("vl_custo_base")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlMarkup)
                    .HasColumnName("vl_markup")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlPrecoVenda)
                    .HasColumnName("vl_preco_venda")
                    .HasColumnType("numeric(15,2)");

                entity.HasOne(d => d.IdCorNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cor_produto_fk");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grupo_produto_fk");

                entity.HasOne(d => d.IdGradeNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdGrade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("grade_produto_fk");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("marca_produto_fk");
            });

            modelBuilder.Entity<ProdutoFornecedor>(entity =>
            {
                entity.HasKey(e => e.IdProdutoFornecedor)
                    .HasName("produto_fornecedor_pk");

                entity.ToTable("produto_fornecedor");

                entity.Property(e => e.IdProdutoFornecedor)
                    .HasColumnName("id_produto_fornecedor")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ProdutoFornecedor)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_produto_fornecedor_fk");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoFornecedor)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_produto_fornecedor_fk");
            });

            modelBuilder.Entity<ProdutoTamanho>(entity =>
            {
                entity.HasKey(e => e.IdProdutoTamanho)
                    .HasName("produto_tamanho_pk");

                entity.ToTable("produto_tamanho");

                entity.Property(e => e.IdProdutoTamanho)
                    .HasColumnName("id_produto_tamanho")
                    .HasDefaultValueSql("nextval('produto_tamanho_id_produto_tamanho_seq_1'::regclass)");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.IdTamanho).HasColumnName("id_tamanho");

                entity.Property(e => e.VlQuantidade).HasColumnName("vl_quantidade");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoTamanho)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_produto_tamanho_fk");

                entity.HasOne(d => d.IdTamanhoNavigation)
                    .WithMany(p => p.ProdutoTamanho)
                    .HasForeignKey(d => d.IdTamanho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tamanho_produto_tamanho_fk");
            });

            modelBuilder.Entity<ProfissionalPessoal>(entity =>
            {
                entity.HasKey(e => e.IdProfissionalPessoal)
                    .HasName("profissional_pessoal_pk");

                entity.ToTable("profissional_pessoal");

                entity.Property(e => e.IdProfissionalPessoal).HasColumnName("id_profissional_pessoal");

                entity.Property(e => e.DsAtividade)
                    .IsRequired()
                    .HasColumnName("ds_atividade")
                    .HasMaxLength(100);

                entity.Property(e => e.DsEndereco)
                    .IsRequired()
                    .HasColumnName("ds_endereco")
                    .HasMaxLength(500);

                entity.Property(e => e.DsTelefone)
                    .IsRequired()
                    .HasColumnName("ds_telefone")
                    .HasMaxLength(50);

                entity.Property(e => e.DsTrabalhoProfi)
                    .IsRequired()
                    .HasColumnName("ds_trabalho_profi")
                    .HasMaxLength(100);

                entity.Property(e => e.IeEscolaridadePessoal)
                    .HasColumnName("ie_escolaridade_pessoal")
                    .HasMaxLength(100);

                entity.Property(e => e.IeEstadoCivil)
                    .HasColumnName("ie_estado_civil")
                    .HasMaxLength(50);

                entity.Property(e => e.NmConjuge)
                    .HasColumnName("nm_conjuge")
                    .HasMaxLength(100);

                entity.Property(e => e.NrDependentes).HasColumnName("nr_dependentes");

                entity.Property(e => e.VlRendaMensal)
                    .HasColumnName("vl_renda_mensal")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlSalario)
                    .HasColumnName("vl_salario")
                    .HasColumnType("numeric(15,2)");

                entity.Property(e => e.VlTempoServico).HasColumnName("vl_tempo_servico");
            });

            modelBuilder.Entity<Referencias>(entity =>
            {
                entity.HasKey(e => e.IdReferencias)
                    .HasName("referencias_pk");

                entity.ToTable("referencias");

                entity.Property(e => e.IdReferencias).HasColumnName("id_referencias");

                entity.Property(e => e.DsTelefone)
                    .HasColumnName("ds_telefone")
                    .HasMaxLength(50);

                entity.Property(e => e.DsVinculado)
                    .HasColumnName("ds_vinculado")
                    .HasMaxLength(100);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NmReferencia)
                    .HasColumnName("nm_referencia")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Referencias)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_referencias__fk");
            });

            modelBuilder.Entity<Tamanho>(entity =>
            {
                entity.HasKey(e => e.IdTamanho)
                    .HasName("tamanho_pk");

                entity.ToTable("tamanho");

                entity.Property(e => e.IdTamanho)
                    .HasColumnName("id_tamanho")
                    .HasDefaultValueSql("nextval('tamanho_id_tamanho_seq_1'::regclass)");

                entity.Property(e => e.DsTamanho)
                    .IsRequired()
                    .HasColumnName("ds_tamanho")
                    .HasMaxLength(50);

                entity.Property(e => e.DtAtualizado)
                    .HasColumnName("dt_atualizado")
                    .HasColumnType("date");

                entity.Property(e => e.DtCadastro)
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("usuario_pk");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasDefaultValueSql("nextval('usuario_id_usuario_seq_1'::regclass)");

                entity.Property(e => e.CdSenha)
                    .IsRequired()
                    .HasColumnName("cd_senha")
                    .HasMaxLength(100);

                entity.Property(e => e.NmLogin)
                    .IsRequired()
                    .HasColumnName("nm_login")
                    .HasMaxLength(100);
            });

            modelBuilder.HasSequence("crediario_id_crediario_seq_1");

            modelBuilder.HasSequence("notafiscal_id_pedido_seq");

            modelBuilder.HasSequence("produto_tamanho_id_produto_tamanho_seq_1");

            modelBuilder.HasSequence("tamanho_id_tamanho_seq_1");

            modelBuilder.HasSequence("usuario_id_usuario_seq_1");
        }
    }
}
