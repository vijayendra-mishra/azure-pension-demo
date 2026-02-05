# Changelog

## [1.8.0](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.7.0...v1.8.0) (2026-02-05)


### Features

* update pension query test data with new employee information ([5509ed0](https://github.com/vijayendra-mishra/azure-pension-demo/commit/5509ed039ced26bc31cac50ab3e11b1b54787f95))
* update pension query test data with new employee information ([32c21e5](https://github.com/vijayendra-mishra/azure-pension-demo/commit/32c21e50a80270aa87d53acbbeeb63bc9dd122d4))

## [1.7.0](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.6.1...v1.7.0) (2026-02-05)


### Features

* add terraform file change detection and skip infrastructure job if no changes ([c4fbe57](https://github.com/vijayendra-mishra/azure-pension-demo/commit/c4fbe57c3927eaf1e0920329539cbf6fb7d72a13))
* add terraform plan to dev and prod deployments and add AI code review workflow ([f3c3cce](https://github.com/vijayendra-mishra/azure-pension-demo/commit/f3c3cce37bf26b4fb411ab968117075c2cf957ea))


### Bug Fixes

* combine terraform init and workspace select to prevent hanging, add -input=false ([0460544](https://github.com/vijayendra-mishra/azure-pension-demo/commit/04605440c5ec517d8566ac013ea2cff80e920dd4))
* properly configure terraform and azure credentials in workflow ([eff3019](https://github.com/vijayendra-mishra/azure-pension-demo/commit/eff30197a33dcc7f72833ccc8ca37311ede03dfc))
* properly configure terraform and azure credentials in workflow ([aa7d9cd](https://github.com/vijayendra-mishra/azure-pension-demo/commit/aa7d9cd7d92f62d90d56c1f49ac654d9be4b73d3))
* use TF_WORKSPACE environment variable to select workspace before terraform init ([5d7fd25](https://github.com/vijayendra-mishra/azure-pension-demo/commit/5d7fd25784d3f1bb5bfb8eb88ea8e67b5ec5ed2b))

## [1.6.1](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.6.0...v1.6.1) (2026-02-05)


### Bug Fixes

* use release-type simple for .NET project ([da326a6](https://github.com/vijayendra-mishra/azure-pension-demo/commit/da326a60b3eae695116ae1d275c45bd87382c3ef))
* use release-type simple for .NET project ([2c1296e](https://github.com/vijayendra-mishra/azure-pension-demo/commit/2c1296e74fd13aae1ce8dae6edd733c4a050455b))

## [1.6.0](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.5.3...v1.6.0) (2025-09-16)


### Features

* **data:** change Michael Test back to Michael Seils for production … ([b920cec](https://github.com/vijayendra-mishra/azure-pension-demo/commit/b920cec42aa1d73289807785e521c3c19d97af56))
* **data:** change Michael Test back to Michael Seils for production demo ([252b2cd](https://github.com/vijayendra-mishra/azure-pension-demo/commit/252b2cd83b25e3f923ffae3bba8897001a7fc62b))

## [1.5.3](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.5.2...v1.5.3) (2025-09-15)


### Bug Fixes

* **ci-cd:** CRITICAL FIX - use correct commit message format 'chore(m… ([1105510](https://github.com/vijayendra-mishra/azure-pension-demo/commit/1105510027432473a91c94f45c6c933827669b41))
* **ci-cd:** CRITICAL FIX - use correct commit message format 'chore(main): release' with colon ([c21a07a](https://github.com/vijayendra-mishra/azure-pension-demo/commit/c21a07a508104d3b4983eb897020f259ce7d325a))

## [1.5.2](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.5.1...v1.5.2) (2025-09-15)


### Bug Fixes

* **ci-cd:** simplify workflow conditions for reliable deployment ([5117d4a](https://github.com/vijayendra-mishra/azure-pension-demo/commit/5117d4a90712803639c3dd0d5a9e888d67a93d07))
* **ci-cd:** simplify workflow conditions for reliable deployment ([377b368](https://github.com/vijayendra-mishra/azure-pension-demo/commit/377b3681f8afb4382b9512c13742d41cbb7e7f13))

## [1.5.1](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.5.0...v1.5.1) (2025-09-15)


### Bug Fixes

* **ci-cd:** exclude release-please PRs from tests and ensure proper p… ([8bc9f9e](https://github.com/vijayendra-mishra/azure-pension-demo/commit/8bc9f9e9b1f184bf00e05d0870accf963ac25c82))
* **ci-cd:** exclude release-please PRs from tests and ensure proper prod deployment ([7ed491f](https://github.com/vijayendra-mishra/azure-pension-demo/commit/7ed491f61aa2c67602b03197e7cddbd2ced8d503))

## [1.5.0](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.4.5...v1.5.0) (2025-09-15)


### Features

* **data:** update Michael Brown to Michael Test for testing production deployment pipeline ([8e971bd](https://github.com/vijayendra-mishra/azure-pension-demo/commit/8e971bd27227fc86219a95bc43a4ced2fec6a3be))

## [1.4.5](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.4.4...v1.4.5) (2025-09-15)


### Bug Fixes

* **ci-cd:** correct workflow to deploy prod only on release commits, … ([b8ea112](https://github.com/vijayendra-mishra/azure-pension-demo/commit/b8ea1126f3ccbf7c8298c589400348802acfa9f2))
* **ci-cd:** correct workflow to deploy prod only on release commits, not dev ([0b8e5de](https://github.com/vijayendra-mishra/azure-pension-demo/commit/0b8e5de30fef3b5f8755476a2554c168545f6c82))

## [1.4.4](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.4.3...v1.4.4) (2025-09-15)


### Bug Fixes

* **ci-cd:** correct production deployment trigger to use release even… ([0b9cad4](https://github.com/vijayendra-mishra/azure-pension-demo/commit/0b9cad4f473cc2b96b4658d6a41b1b4cc2ed8026))
* **ci-cd:** correct production deployment trigger to use release events instead of commit message detection ([7fda610](https://github.com/vijayendra-mishra/azure-pension-demo/commit/7fda610e9d131b9ae9b589aaab860ce0eea62135))

## [1.4.3](https://github.com/vijayendra-mishra/azure-pension-demo/compare/v1.4.2...v1.4.3) (2025-09-15)


### Bug Fixes

* **ci-cd:** fix YAML conditional expressions syntax errors ([9313bc9](https://github.com/vijayendra-mishra/azure-pension-demo/commit/9313bc9dd4aaaa5f9c44f1f884ea98db39ffb705))
* **data:** update pension data - change Michael Seils to Michael Brown ([704a778](https://github.com/vijayendra-mishra/azure-pension-demo/commit/704a7782c6e6c447b83e59a6333bc4932d18aa42))
