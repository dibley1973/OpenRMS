require 'spec_helper'
describe 'dnx' do

  context 'with defaults for all parameters' do
    it { should contain_class('dnx') }
  end
end
